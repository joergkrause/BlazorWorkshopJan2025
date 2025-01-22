using System.ComponentModel.DataAnnotations;
using Workshop.ViewModels.Attributes;

namespace Workshop.ViewModels
{
  public class ProductEditViewModel
  {
    [Required]
    [StringLength(100)]
    [Display(Name = "Produktname", Description ="Das ist der Name des Produkts", Order = 100)]
    [AccessKey('n')]
    public string Name { get; set; } = default!;

    [Range(0, 1000)]
    [Display(Name = "Artikelpreis", Description = "Das ist der Preis des Artikels in €", Order = 200)]
    [DataType(DataType.Currency)]
    [UIHint("€")]
    [DisplayFormat(DataFormatString = "{0.00}")]
    [AccessKey('p')]
    public decimal Price { get; set; }

    public ProductViewModel GetProductViewModel()
    {
      return new ProductViewModel
      {
        Name = Name,
        Price = Price
      };
    }

  }
}
