using System.ComponentModel.DataAnnotations;

namespace P010Store.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50), Display(Name = "Marka Adı")]
        public string Name { get; set; }
        [Display(Name = "Marka Açıklaması")]
        public string? Description { get; set; }
        [StringLength(150)]
        public string? Logo { get; set; } = ""; // property e varsayılan değer atama
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)] // ScaffoldColumn(false) demek view lar oluşturulurken bu alan ekranda oluşturulmasın demektir.
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public virtual ICollection<Product>? Products { get; set; } // Marka ile Ürünler arasında 1 e çok ilişki kurduk
    }
}
