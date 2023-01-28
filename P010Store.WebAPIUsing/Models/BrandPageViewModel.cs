using P010Store.Entities;

namespace P010Store.WebAPIUsing.Models
{
    public class BrandPageViewModel
    {
        public Brand Brand { get; set; }
        public List<Product>? Products { get; set; }
    }
}
