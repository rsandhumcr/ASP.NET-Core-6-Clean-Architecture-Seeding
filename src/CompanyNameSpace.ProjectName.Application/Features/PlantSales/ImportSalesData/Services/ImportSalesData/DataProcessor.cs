using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;
using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;
using CompanyNameSpace.ProjectName.Application.Utils;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;
using System.Drawing;
using System.Linq;

namespace CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Services.ImportSalesData;

public class DataProcessor : IDataProcessor
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _saleRepository;

    public DataProcessor(
        IMapper mapper,
        IDepartmentRepository departmentRepository,
        IProductRepository productRepository,
        ISaleRepository saleRepository)
    {
        _mapper = mapper;
        _departmentRepository = departmentRepository;
        _productRepository = productRepository;
        _saleRepository = saleRepository;
    }


    public List<Domain.ImportData.SalesData.ImportSalesData> ProcessJsonData(ImportSalesDataCommand request)
    {
        var stringDataList = request.FileImports.Select(itm => itm.Data).ToList();
        var data = GeneralUtils.ConvertJsonData<Domain.ImportData.SalesData.ImportSalesData>(stringDataList);
        foreach (var importSalesData in data)
        foreach (var productFileData in importSalesData.Products)
        foreach (var sale in productFileData.Sales)
            sale.ProductId = productFileData.ProductId;
        return data;
    }

    public List<Department> ExtractDepartmentsAndConvertToDbEntity(List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        if (importedDataObjectList == null)
            return new List<Department>();

        var departments = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .Select(itm => itm.Department)
            .DistinctBy(itm => new { itm.Name, itm.DepartmentCode })
            .ToList();
        var departmentsDb = _mapper.Map<List<Department>>(departments);
        return departmentsDb;
    }

    public async Task<ProcessDepartmentDataResult> ProcessDepartmentData(List<Department> departmentDbList)
    {
        if (!departmentDbList.Any())
            return new ProcessDepartmentDataResult();

        var departmentNames = departmentDbList
            .Select(dpt => dpt.Name).Distinct().ToList();

        var departmentsDbItems = await _departmentRepository
            .GetByNames(departmentNames);

        var storedDepartmentCodes = departmentsDbItems
            .Select(dpt => dpt.DepartmentCode)
            .ToList();

        var missingDepartments = departmentDbList
            .Where(dtp => !storedDepartmentCodes.Contains(dtp.DepartmentCode))
            .ToList();

        var newDeptDataDb = await _departmentRepository.BulkAddAsync(missingDepartments);

        var newRecordAddCount = newDeptDataDb.Count;
        newDeptDataDb.AddRange(departmentsDbItems);
        return new ProcessDepartmentDataResult
        {
            Departments = newDeptDataDb, DepartmentsAdded = newRecordAddCount,
            DepartmentsUploaded = departmentNames.Count
        };
    }


    public List<Product> ExtractProductsAndConvertToDbEntity(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        if (importedDataObjectList == null)
            return new List<Product>();

        var products = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .DistinctBy(itm => new { itm.Name, itm.Code }).ToList();

        var productsDb = _mapper.Map<List<Product>>(products);
        return productsDb;
    }

    public async Task<ProcessProductDataResult> ProcessProductData(IReadOnlyCollection<Department>? departments,  
        List<Product> productsList)
    {
        if (!productsList.Any())
            return new ProcessProductDataResult();

        var productCodes = productsList
            .Select(dpt => dpt.Code).Distinct().ToList();

        var productDbItems = await _productRepository.GetByCodes(productCodes);
        var storedProductCodes = productDbItems.Select(dpt => dpt.Code).ToList();

        var missingProducts = productsList
            .Where(dtp =>
                !storedProductCodes.Contains(dtp.Code)).ToList();

        if (departments != null)
        {
            var departmentsList = departments.ToList();
            foreach (var product in missingProducts)
            {
                if (product.Department != null)
                {
                    var foundDept = departmentsList
                        .Find(itm => itm.DepartmentCode == product.Department.DepartmentCode);
                    if (foundDept != null) product.DepartmentId = foundDept.DepartmentId;
                    product.Department = null;
                }

                product.Sales = null;
            }
        }

        var newProductList = await _productRepository.BulkAddAsync(missingProducts);

        var newRecordAddCount = newProductList.Count();
        newProductList.AddRange(productDbItems);

        return new ProcessProductDataResult
        {
            Products = newProductList, ProductsAdded = newRecordAddCount,
            ProductsUploaded = productCodes.Count
        };
    }

    public List<Sale> ExtractSalesAndConvertToDbEntity(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        if (importedDataObjectList == null)
            return new List<Sale>();

        var sales = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .SelectMany(itm => itm.Sales)
            .ToList();

        var salesData = _mapper.Map<List<Sale>>(sales);
        var salesUnique = salesData.Distinct(new ComparerSale()).ToList();
        return salesUnique;
    }

    public async Task<ProcessSaleDataResult> ProcessSaleData(IReadOnlyCollection<Sale>? sales)
    {
        if (sales == null || !sales.Any())
            return new ProcessSaleDataResult();

        var productIds = sales
            .Select(itm => itm.ProductId).Distinct().ToList();
        var newSalesList = new List<Sale>();

        foreach (var productId in productIds)
        {
            var startDate = sales
                .Where(itm => itm.ProductId == productId)
                .Min(itm => itm.From);
            var endDate = sales
                .Where(itm => itm.ProductId == productId)
                .Max(itm => itm.Until);
            var foundSales =
                await _saleRepository.GetSalesBetweenDatesAndByProductId(startDate, endDate, productId);

            var salesForProduct = sales.Where(itm => itm.ProductId == productId).ToList();
            foreach (var sale in salesForProduct)
            {
                var specificSales = foundSales
                    .Where(itm => itm.From == sale.From 
                                  && itm.Until == sale.Until 
                                  && itm.ProductId == sale.ProductId).ToList();
                if (!specificSales.Any()) newSalesList.Add(sale);
            }
        }

        await _saleRepository.BulkAddAsync(newSalesList);

        return new ProcessSaleDataResult
        {
            SalesAdded = newSalesList.Count, SalesUploaded = sales.Count,
            Sales = newSalesList
        };
    }
}

public class ComparerSale : IEqualityComparer<Sale>
{
    public bool Equals(Sale? x, Sale? y)
    {
        if (x == null && y == null)
            return true;
        if (x != null && y == null)
            return false;
        if (x == null && y != null)
            return false;
        return x.ProductId == y.ProductId && x.From == y.From && x.Until == y.Until && x.Quantity == y.Quantity;
    }

    public int GetHashCode(Sale obj)
    {
        return
            obj.ProductId.GetHashCode() +
            obj.From.GetHashCode() +
            obj.Until.GetHashCode() +
            obj.Quantity.GetHashCode();
    }
}

public class ProcessDepartmentDataResult
{
    public int DepartmentsAdded { get; set; }
    public int DepartmentsUploaded { get; set; }
    public IReadOnlyCollection<Department>? Departments { get; set; }
}

public class ProcessProductDataResult
{
    public int ProductsAdded { get; set; }
    public int ProductsUploaded { get; set; }
    public IReadOnlyCollection<Product>? Products { get; set; }
}

public class ProcessSaleDataResult
{
    public int SalesAdded { get; set; }
    public int SalesUploaded { get; set; }
    public IReadOnlyCollection<Sale>? Sales { get; set; }
}