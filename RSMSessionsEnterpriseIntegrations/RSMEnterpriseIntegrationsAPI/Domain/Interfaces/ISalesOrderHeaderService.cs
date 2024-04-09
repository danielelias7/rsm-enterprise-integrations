namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;

    public interface ISalesOrderHeaderService
    {
        Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id);
        Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll();
        Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto SalesOrderHeaderDto);
        Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto SalesOrderHeaderDto);
        Task<int> DeleteSalesOrderHeader(int id);
    }
}