using P010Store.Entities;

namespace P010Store.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<Product>? Products { get; set; }
    }
}
