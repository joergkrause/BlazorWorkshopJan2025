using System.ComponentModel.DataAnnotations;
using Workshop.ViewModels.Attributes;

namespace Workshop.ViewModels
{
  public class ProductViewModel
  {
    [Hidden]
    public int Id { get; set; }

    [Display(Name = "Artikelname")]
    public string Name { get; set; } = default!;

    [Hidden]
    //[DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Artikelname")]
    public string PriceString => $"{Price} €";

    [UIHint("Edit", "Buttons")]
    public string EditLink => $"/products/{Id}";

    public ProductEditViewModel GetProductEditViewModel()
    {
      return new ProductEditViewModel
      {
        Id = Id,
        Name = Name,
        Price = Price
      };
    }

  }
}