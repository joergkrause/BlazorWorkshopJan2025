using Fluxor;
using System.Collections.ObjectModel;
using Workshop.Datasource;
using Workshop.ViewModels;

namespace Workshop.BlazorApp.Components.Stores.ProductsStore
{
  [Selector]
  public class ProductSelectors(IState<ProductsState> state)
  {
    public ObservableCollection<ProductViewModel> Products => state.Value.Products.Products;

    public int Count => state.Value.Products.Products.Count;

    public ProductEditViewModel CreateEditModel(ProductViewModel product)
    {
      return new ProductEditViewModel
      {
        Name = product.Name,
        Price = product.Price
      };
    }
  }
}
