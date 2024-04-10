namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product information is not provided.");
            }

            if (string.IsNullOrWhiteSpace(productDto.Name) ||
                string.IsNullOrWhiteSpace(productDto.ProductNumber) ||
                string.IsNullOrWhiteSpace(productDto.Size) ||
                string.IsNullOrWhiteSpace(productDto.SizeUnitMeasureCode) ||
                string.IsNullOrWhiteSpace(productDto.WeightUnitMeasureCode))
            {
                throw new BadRequestException("One or more required fields are missing or invalid.");
            }

            Product product = new()
            {
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                MakeFlag = productDto.MakeFlag,
                FinishedGoodsFlag = productDto.FinishedGoodsFlag,
                Color = productDto.Color,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                Size = productDto.Size,
                SizeUnitMeasureCode = productDto.SizeUnitMeasureCode,
                WeightUnitMeasureCode = productDto.WeightUnitMeasureCode,
                Weight = productDto.Weight,
                DaysToManufacture = productDto.DaysToManufacture,
                ProductLine = productDto.ProductLine,
                Class = productDto.Class,
                Style = productDto.Style,
                ProductSubcategoryID = productDto.ProductSubcategoryID,
                ProductModelID = productDto.ProductModelID,
                SellStartDate = productDto.SellStartDate,
                SellEndDate = productDto.SellEndDate,
                DiscontinuedDate = productDto.DiscontinuedDate
            };

            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.DeleteProduct(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> productsDto = new();

            foreach (var product in products)
            {
                GetProductDto dto = new()
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    MakeFlag = product.MakeFlag,
                    FinishedGoodsFlag = product.FinishedGoodsFlag,
                    Color = product.Color,
                    SafetyStockLevel = product.SafetyStockLevel,
                    ReorderPoint = product.ReorderPoint,
                    StandardCost = product.StandardCost,
                    ListPrice = product.ListPrice,
                    Size = product.Size,
                    SizeUnitMeasureCode = product.SizeUnitMeasureCode,
                    WeightUnitMeasureCode = product.WeightUnitMeasureCode,
                    Weight = product.Weight,
                    DaysToManufacture = product.DaysToManufacture,
                    ProductLine = product.ProductLine,
                    Class = product.Class,
                    Style = product.Style,
                    ProductSubcategoryID = product.ProductSubcategoryID,
                    ProductModelID = product.ProductModelID,
                    SellStartDate = product.SellStartDate,
                    SellEndDate = product.SellEndDate,
                    DiscontinuedDate = product.DiscontinuedDate
                };
                productsDto.Add(dto);
            }

            return productsDto;
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Product ID is not valid");
            }

            var product = await ValidateProductExistence(id);

            GetProductDto dto = new()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                MakeFlag = product.MakeFlag,
                FinishedGoodsFlag = product.FinishedGoodsFlag,
                Color = product.Color,
                SafetyStockLevel = product.SafetyStockLevel,
                ReorderPoint = product.ReorderPoint,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                SizeUnitMeasureCode = product.SizeUnitMeasureCode,
                WeightUnitMeasureCode = product.WeightUnitMeasureCode,
                Weight = product.Weight,
                DaysToManufacture = product.DaysToManufacture,
                ProductLine = product.ProductLine,
                Class = product.Class,
                Style = product.Style,
                ProductSubcategoryID = product.ProductSubcategoryID,
                ProductModelID = product.ProductModelID,
                SellStartDate = product.SellStartDate,
                SellEndDate = product.SellEndDate,
                DiscontinuedDate = product.DiscontinuedDate
            };
            return dto;
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if(productDto is null)
            {
                throw new BadRequestException("Product category info is not valid.");
            }
            var product = await ValidateProductExistence(productDto.ProductID);

            product.Name = string.IsNullOrWhiteSpace(productDto.Name) ? product.Name : productDto.Name;
            product.ProductNumber = string.IsNullOrWhiteSpace(productDto.ProductNumber) ? product.ProductNumber : productDto.ProductNumber;
            product.MakeFlag = productDto.MakeFlag;
            product.FinishedGoodsFlag = productDto.FinishedGoodsFlag;
            product.Color = string.IsNullOrWhiteSpace(productDto.Color) ? product.Color : productDto.Color;
            product.SafetyStockLevel = productDto.SafetyStockLevel <= 0 ? product.SafetyStockLevel : productDto.SafetyStockLevel;
            product.ReorderPoint = productDto.ReorderPoint <= 0 ? product.ReorderPoint : productDto.ReorderPoint;
            product.StandardCost = productDto.StandardCost <= 0 ? product.StandardCost : productDto.StandardCost;
            product.ListPrice = productDto.ListPrice <= 0 ? product.ListPrice : productDto.ListPrice;
            product.Size = string.IsNullOrWhiteSpace(productDto.Size) ? product.Size : productDto.Size;
            product.SizeUnitMeasureCode = string.IsNullOrWhiteSpace(productDto.SizeUnitMeasureCode) ? product.SizeUnitMeasureCode : productDto.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = string.IsNullOrWhiteSpace(productDto.WeightUnitMeasureCode) ? product.WeightUnitMeasureCode : productDto.WeightUnitMeasureCode;
            product.Weight = productDto.Weight <= 0 ? product.Weight : productDto.Weight;
            product.DaysToManufacture = productDto.DaysToManufacture <= 0 ? product.DaysToManufacture : productDto.DaysToManufacture;
            product.ProductLine = string.IsNullOrWhiteSpace(productDto.ProductLine) ? product.ProductLine : productDto.ProductLine;
            product.Class = string.IsNullOrWhiteSpace(productDto.Class) ? product.Class : productDto.Class;
            product.Style = string.IsNullOrWhiteSpace(productDto.Style) ? product.Style : productDto.Style;
            product.ProductSubcategoryID = productDto.ProductSubcategoryID ?? product.ProductSubcategoryID;
            product.ProductModelID = productDto.ProductModelID ?? product.ProductModelID;
            product.SellStartDate = productDto.SellStartDate == default ? product.SellStartDate : productDto.SellStartDate;
            product.SellEndDate = productDto.SellEndDate;
            product.DiscontinuedDate = productDto.DiscontinuedDate;

            return await _productRepository.UpdateProduct(product);
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var existingProduct = await _productRepository.GetProductById(id) 
                ?? throw new NotFoundException($"Product with Id: {id} was not found.");

            return existingProduct;
        }

    }
}
