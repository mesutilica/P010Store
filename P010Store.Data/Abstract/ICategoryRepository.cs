using P010Store.Entities;

namespace P010Store.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByProducts(int id);
    }
}
