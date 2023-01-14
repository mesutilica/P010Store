using Microsoft.EntityFrameworkCore;
using P010Store.Data.Abstract;
using P010Store.Entities;

namespace P010Store.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoriesBrandsAsync()
        {
            return await context.Products.Include(c => c.Category).Include(b => b.Brand).AsNoTracking().ToListAsync(); // bu metot geriye ürün listesi dönecek ve listedeki her bir ürüne o ürünün kategorisi ve markası da dahil edilecek. context üzerinden Products a erişip ef core un include metoduyla hem ürünün kategorisini hem de markasını products a dahil edip en son tolistasync diyerek listeleyip verilieri döndürüyoruz.
        }
    }
}
