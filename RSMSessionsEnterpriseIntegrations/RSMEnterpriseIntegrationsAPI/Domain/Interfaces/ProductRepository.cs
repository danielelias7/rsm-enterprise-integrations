namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<int> CreateProduct(Product department);
        Task<int> UpdateProduct(Product department);
        Task<int> DeleteProduct(Product department);
    }
}
