namespace Workshop.ViewModels
{
  public class ProductListViewModel
  {
    public IList<ProductViewModel> Products { get; set; } = [];

    public int Count => Products.Count;
  }
}
