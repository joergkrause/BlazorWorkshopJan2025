using System.Collections.ObjectModel;

namespace Workshop.ViewModels
{
  public class ProductListViewModel(ObservableCollection<ProductViewModel> products)
  {
    public ObservableCollection<ProductViewModel> Products { get; set; } = products;

    public int Count => Products.Count;
  }
}
