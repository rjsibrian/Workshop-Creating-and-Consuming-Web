namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;

    public interface ISalesOrderHeaderService
    {
        Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id);
        Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll();
        Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto);
        Task<int> DeleteSalesOrderHeader(int id);
    }
}
