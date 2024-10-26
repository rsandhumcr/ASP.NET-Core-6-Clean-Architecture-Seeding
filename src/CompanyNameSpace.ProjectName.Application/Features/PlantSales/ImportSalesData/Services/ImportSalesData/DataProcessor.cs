using AutoMapper;
using CompanyNameSpace.ProjectName.Application.Contracts.Persistence.Sales;
using CompanyNameSpace.ProjectName.Application.Features.PlantSales.ImportSalesData.Commands.ImportSalesData;
using CompanyNameSpace.ProjectName.Application.Utils;
using CompanyNameSpace.ProjectName.Domain.Entities.Sales;

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

    public async Task<ProcessDepartmentDataResult> ProcessDepartmentData(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        var departments = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .Select(itm => itm.Department).DistinctBy(itm => new { itm.Name, itm.DepartmentCode }).ToList();

        var departmentNames = departments
            .Select(dpt => dpt.Name).Distinct().ToList();

        var departmentsDbItems = await _departmentRepository.GetByNames(departmentNames);
        var storedDepartments = departmentsDbItems.Select(dpt => dpt.DepartmentCode).ToList();

        var missingDepartments = departments
            .Where(dtp =>
                !storedDepartments.Contains(dtp.DepartmentCode)).ToList();

        var departmentsDb = _mapper.Map<List<Department>>(missingDepartments);

        var newDeptDataDb = await _departmentRepository.BulkAddAsync(departmentsDb);

        var newRecordAddCount = newDeptDataDb.Count;

        var resultList = newDeptDataDb;
        resultList.AddRange(departmentsDbItems);
        return new ProcessDepartmentDataResult
        {
            Departments = resultList, DepartmentsAdded = newRecordAddCount,
            DepartmentsUploaded = departmentNames.Count
        };
    }

    public async Task<ProcessProductDataResult> ProcessProductData(IReadOnlyCollection<Department>? departments,
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        var products = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .DistinctBy(itm => new { itm.Name, itm.Code }).ToList();

        var productCodes = products
            .Select(dpt => dpt.Code).Distinct().ToList();

        var productDbItems = await _productRepository.GetByCodes(productCodes);
        var storedProducts = productDbItems.Select(dpt => dpt.Code).ToList();

        var missingProducts = products
            .Where(dtp =>
                !storedProducts.Contains(dtp.Code)).ToList();

        var productsDb = _mapper.Map<List<Product>>(missingProducts);

        var newProductData = new List<Product>();
        if (departments != null)
        {
            var departmentsList = departments.ToList();
            foreach (var product in productsDb)
            {
                if (product.Department != null)
                {
                    var foundDept = departmentsList
                        .Find(itm => itm.DepartmentCode == product.Department.DepartmentCode);
                    if (foundDept != null) product.DepartmentId = foundDept.DepartmentId;
                    product.Department = null;
                }

                product.Sales = null;
                newProductData.Add(product);
            }
        }

        var newProductList = await _productRepository.BulkAddAsync(newProductData);

        var newRecordAddCount = newProductList.Count();
        var productList = newProductList;
        productList.AddRange(productDbItems);

        return new ProcessProductDataResult
        {
            Products = productList, ProductsAdded = newRecordAddCount,
            ProductsUploaded = productCodes.Count
        };
    }

    public async Task<ProcessSaleDataResult> ProcessSaleData(
        List<Domain.ImportData.SalesData.ImportSalesData>? importedDataObjectList)
    {
        var sales = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .SelectMany(itm => itm.Sales)
            .ToList();

        var salesData = _mapper.Map<List<Sale>>(sales);
        var productIds = salesData
            .Select(itm => itm.ProductId).Distinct().ToList();
        var newSalesList = new List<Sale>();
        foreach (var productId in productIds)
        {
            var startDate = salesData
                .Where(itm => itm.ProductId == productId)
                .Min(itm => itm.From);
            var endDate = salesData
                .Where(itm => itm.ProductId == productId)
                .Max(itm => itm.Until);
            var foundSales =
                await _saleRepository.GetSalesBetweenDatesAndByProductId(startDate, endDate, productId);

            var salesForProduct = salesData.Where(itm => itm.ProductId == productId).ToList();
            foreach (var sale in salesForProduct)
            {
                var specificSales = foundSales.Where(itm =>
                    itm.From == sale.From && itm.Until == sale.Until
                                          && itm.ProductId == sale.ProductId).ToList();
                if (!specificSales.Any()) newSalesList.Add(sale);
            }
        }

        await _saleRepository.BulkAddAsync(newSalesList);

        return new ProcessSaleDataResult { SalesAdded = newSalesList.Count, SalesUploaded = salesData.Count };
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
}