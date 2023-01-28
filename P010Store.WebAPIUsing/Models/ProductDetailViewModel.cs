using P010Store.Entities;

namespace P010Store.WebAPIUsing.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<Product>? Products { get; set; }
    }
}
