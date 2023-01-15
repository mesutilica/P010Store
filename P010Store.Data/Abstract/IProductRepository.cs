using P010Store.Entities;

namespace P010Store.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsByCategoriesBrandsAsync(); // Task bu metodun asenkron bir metot olduğunu belirtir
        Task<Product> GetProductByCategoriesBrandsAsync(int id);
    }
}
