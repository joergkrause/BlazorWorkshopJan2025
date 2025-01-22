using Fluxor;
using System.Collections.ObjectModel;
using Workshop.ViewModels;

namespace Workshop.BlazorApp.Components.Stores.ProductsStore
{

  [FeatureState(CreateInitialStateMethodName = nameof(InitProductState))]
  public record ProductsState(bool IsLoading, bool IsSaving, bool IsEditing, ProductListViewModel Products, ProductViewModel? PreviousProduct, string Error)
  {
    private static ProductsState InitProductState() => new (false, false, false, new ProductListViewModel(new ObservableCollection<ProductViewModel>()), null, string.Empty);
  }
}
