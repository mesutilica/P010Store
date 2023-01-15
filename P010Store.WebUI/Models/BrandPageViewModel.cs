using P010Store.Entities;

namespace P010Store.WebUI.Models
{
    public class BrandPageViewModel
    {
        public Brand Brand { get; set; }
        public List<Product>? Products { get; set; }
    }
}
