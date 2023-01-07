using P010Store.Data;
using P010Store.Data.Concrete;
using P010Store.Service.Abstract;

namespace P010Store.Service.Concrete
{
    public class ProductService : ProductRepository, IProductService
    {
        public ProductService(DatabaseContext _context) : base(_context)
        {
        }
    }
}
