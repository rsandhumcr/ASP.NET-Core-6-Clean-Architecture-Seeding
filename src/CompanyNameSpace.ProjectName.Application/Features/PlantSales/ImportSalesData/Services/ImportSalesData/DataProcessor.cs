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
        List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList)
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

        var newDeptData = new List<Department>();
        foreach (var department in departmentsDb)
        {
            var newDept = await _departmentRepository.AddAsync(department);
            newDeptData.Add(newDept);
        }

        var newCount = newDeptData.Count;

        var resultList = newDeptData;
        resultList.AddRange(departmentsDbItems);
        return new ProcessDepartmentDataResult { Departments = resultList, DepartmentAdded = newCount };
    }

    public async Task<ProcessProductDataResult> ProcessProductData(IReadOnlyCollection<Department> departments,
        List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList)
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
        var departmentsList = departments.ToList();
        foreach (var product in productsDb)
        {
            if (product.Department != null)
            {
                var foundDept = departmentsList
                    .Find(itm => itm.DepartmentCode == product.Department.DepartmentCode);
                product.DepartmentId = foundDept.DepartmentId;
                product.Department = null;
            }

            product.Sales = null;
            var newProduct = await _productRepository.AddAsync(product);
            newProductData.Add(newProduct);
        }

        var newCount = newProductData.Count();
        var productList = newProductData;
        productList.AddRange(productDbItems);

        return new ProcessProductDataResult { Products = productList, ProductAdded = newCount };
    }

    public async Task<int> ProcessSaleData(List<Domain.ImportData.SalesData.ImportSalesData> importedDataObjectList)
    {
        var sales = importedDataObjectList
            .SelectMany(itm => itm.Products)
            .SelectMany(itm => itm.Sales)
            .ToList();

        var salesData = _mapper.Map<List<Sale>>(sales);
        var count = 0;
        foreach (var sale in salesData)
        {
            var foundSale =
                await _saleRepository.GetBySalesDatesAndProductId(sale.From, sale.Until.Date, sale.ProductId);
            if (!foundSale.Any())
            {
                var newSale = await _saleRepository.AddAsync(sale);
                count++;
            }
        }

        return count;
    }
}

public class ProcessDepartmentDataResult
{
    public int DepartmentAdded { get; set; }
    public IReadOnlyCollection<Department> Departments { get; set; }
}

public class ProcessProductDataResult
{
    public int ProductAdded { get; set; }
    public IReadOnlyCollection<Product> Products { get; set; }
}