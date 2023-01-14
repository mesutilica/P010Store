using P010Store.Entities;

namespace P010Store.WebUI.Models
{
    public class HomePageViewModel
    {
        public List<Carousel>? Carousels { get; set; }
        public List<Product>? Products { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}
