namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
        public SalesOrderHeaderService(ISalesOrderHeaderRepository repository)
        {
            _salesOrderHeaderRepository = repository;
        }

        public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null)
            {
                throw new BadRequestException("SalesOrderHeader information is not provided.");
            }

            SalesOrderHeader salesOrderHeader = new()
            {
                RevisionNumber = salesOrderHeaderDto.RevisionNumber,
                OrderDate = salesOrderHeaderDto.OrderDate,
                DueDate = salesOrderHeaderDto.DueDate,
                ShipDate = salesOrderHeaderDto.ShipDate,
                Status = salesOrderHeaderDto.Status,
                OnlineOrderFlag = salesOrderHeaderDto.OnlineOrderFlag,
                PurchaseOrderNumber = salesOrderHeaderDto.PurchaseOrderNumber,
                AccountNumber = salesOrderHeaderDto.AccountNumber,
                CustomerID = salesOrderHeaderDto.CustomerID,
                SalesPersonID = salesOrderHeaderDto.SalesPersonID,
                TerritoryID = salesOrderHeaderDto.TerritoryID,
                BillToAddressID = salesOrderHeaderDto.BillToAddressID,
                ShipToAddressID = salesOrderHeaderDto.ShipToAddressID,
                ShipMethodID = salesOrderHeaderDto.ShipMethodID,
                CreditCardID = salesOrderHeaderDto.CreditCardID,
                CreditCardApprovalCode = salesOrderHeaderDto.CreditCardApprovalCode,
                CurrencyRateID = salesOrderHeaderDto.CurrencyRateID,
                SubTotal = salesOrderHeaderDto.SubTotal,
                TaxAmt = salesOrderHeaderDto.TaxAmt,
                Freight = salesOrderHeaderDto.Freight,
            };

            return await _salesOrderHeaderRepository.CreateSalesOrderHeader(salesOrderHeader);
        }

        public async Task<int> DeleteSalesOrderHeader(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(id);
            return await _salesOrderHeaderRepository.DeleteSalesOrderHeader(salesOrderHeader);
        }

        public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll()
        {
            var salesOrderHeaders = await _salesOrderHeaderRepository.GetAllSalesOrderHeaders();
            List<GetSalesOrderHeaderDto> salesOrderHeadersDto = new();

            foreach (var salesOrderHeader in salesOrderHeaders)
            {
                GetSalesOrderHeaderDto dto = new()
                {
                    SalesOrderID = salesOrderHeader.SalesOrderID,
                    RevisionNumber = salesOrderHeader.RevisionNumber,
                    OrderDate = salesOrderHeader.OrderDate,
                    DueDate = salesOrderHeader.DueDate,
                    ShipDate = salesOrderHeader.ShipDate,
                    Status = salesOrderHeader.Status,
                    OnlineOrderFlag = salesOrderHeader.OnlineOrderFlag,
                    SalesOrderNumber = salesOrderHeader.SalesOrderNumber,
                    PurchaseOrderNumber = salesOrderHeader.PurchaseOrderNumber,
                    AccountNumber = salesOrderHeader.AccountNumber,
                    CustomerID = salesOrderHeader.CustomerID,
                    SalesPersonID = salesOrderHeader.SalesPersonID,
                    TerritoryID = salesOrderHeader.TerritoryID,
                    BillToAddressID = salesOrderHeader.BillToAddressID,
                    ShipToAddressID = salesOrderHeader.ShipToAddressID,
                    ShipMethodID = salesOrderHeader.ShipMethodID,
                    CreditCardID = salesOrderHeader.CreditCardID,
                    CreditCardApprovalCode = salesOrderHeader.CreditCardApprovalCode,
                    CurrencyRateID = salesOrderHeader.CurrencyRateID,
                    SubTotal = salesOrderHeader.SubTotal,
                    TaxAmt = salesOrderHeader.TaxAmt,
                    Freight = salesOrderHeader.Freight,
                    TotalDue = salesOrderHeader.TotalDue,
                    Comment = salesOrderHeader.Comment
                };
                salesOrderHeadersDto.Add(dto);
            }

            return salesOrderHeadersDto;
        }

        public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Sales Order Header ID is not valid");
            }

            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(id);

            GetSalesOrderHeaderDto dto = new()
            {
                SalesOrderID = salesOrderHeader.SalesOrderID,
                    RevisionNumber = salesOrderHeader.RevisionNumber,
                    OrderDate = salesOrderHeader.OrderDate,
                    DueDate = salesOrderHeader.DueDate,
                    ShipDate = salesOrderHeader.ShipDate,
                    Status = salesOrderHeader.Status,
                    OnlineOrderFlag = salesOrderHeader.OnlineOrderFlag,
                    SalesOrderNumber = salesOrderHeader.SalesOrderNumber,
                    PurchaseOrderNumber = salesOrderHeader.PurchaseOrderNumber,
                    AccountNumber = salesOrderHeader.AccountNumber,
                    CustomerID = salesOrderHeader.CustomerID,
                    SalesPersonID = salesOrderHeader.SalesPersonID,
                    TerritoryID = salesOrderHeader.TerritoryID,
                    BillToAddressID = salesOrderHeader.BillToAddressID,
                    ShipToAddressID = salesOrderHeader.ShipToAddressID,
                    ShipMethodID = salesOrderHeader.ShipMethodID,
                    CreditCardID = salesOrderHeader.CreditCardID,
                    CreditCardApprovalCode = salesOrderHeader.CreditCardApprovalCode,
                    CurrencyRateID = salesOrderHeader.CurrencyRateID,
                    SubTotal = salesOrderHeader.SubTotal,
                    TaxAmt = salesOrderHeader.TaxAmt,
                    Freight = salesOrderHeader.Freight,
                    TotalDue = salesOrderHeader.TotalDue,
                    Comment = salesOrderHeader.Comment
            };
            return dto;
        }

        public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if(salesOrderHeaderDto is null)
            {
                throw new BadRequestException("Product category info is not valid.");
            }
            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(salesOrderHeaderDto.SalesOrderID);

            salesOrderHeader.RevisionNumber = salesOrderHeaderDto.RevisionNumber;
            salesOrderHeader.OrderDate = salesOrderHeaderDto.OrderDate;
            salesOrderHeader.DueDate = salesOrderHeaderDto.DueDate;
            salesOrderHeader.ShipDate = salesOrderHeaderDto.ShipDate;
            salesOrderHeader.Status = salesOrderHeaderDto.Status;
            salesOrderHeader.OnlineOrderFlag = salesOrderHeaderDto.OnlineOrderFlag;
            salesOrderHeader.PurchaseOrderNumber = salesOrderHeaderDto.PurchaseOrderNumber;
            salesOrderHeader.AccountNumber = salesOrderHeaderDto.AccountNumber;
            salesOrderHeader.CustomerID = salesOrderHeaderDto.CustomerID;
            salesOrderHeader.SalesPersonID = salesOrderHeaderDto.SalesPersonID;
            salesOrderHeader.TerritoryID = salesOrderHeaderDto.TerritoryID;
            salesOrderHeader.BillToAddressID = salesOrderHeaderDto.BillToAddressID;
            salesOrderHeader.ShipToAddressID = salesOrderHeaderDto.ShipToAddressID;
            salesOrderHeader.ShipMethodID = salesOrderHeaderDto.ShipMethodID;
            salesOrderHeader.CreditCardID = salesOrderHeaderDto.CreditCardID;
            salesOrderHeader.CreditCardApprovalCode = salesOrderHeaderDto.CreditCardApprovalCode;
            salesOrderHeader.CurrencyRateID = salesOrderHeaderDto.CurrencyRateID;
            salesOrderHeader.SubTotal = salesOrderHeaderDto.SubTotal;
            salesOrderHeader.TaxAmt = salesOrderHeaderDto.TaxAmt;
            salesOrderHeader.Freight = salesOrderHeaderDto.Freight;

            return await _salesOrderHeaderRepository.UpdateSalesOrderHeader(salesOrderHeader);
        }

        private async Task<SalesOrderHeader> ValidateSalesOrderHeaderExistence(int id)
        {
            var existingSalesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id) 
                ?? throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

            return existingSalesOrderHeader;
        }

    }
}
