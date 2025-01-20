namespace Workshop.ViewModels
{
  public class ProductViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Price { get; set; }

    public string PriceString => $"{Price} €";
  }
}