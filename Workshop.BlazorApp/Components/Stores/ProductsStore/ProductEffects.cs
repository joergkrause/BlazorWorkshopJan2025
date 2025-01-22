using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Workshop.Datasource;
using static Workshop.BlazorApp.Components.Stores.ProductsStore.ProductActions;

namespace Workshop.BlazorApp.Components.Stores.ProductsStore
{
  public class ProductEffects(IProductsRepository productsRepository, NavigationManager navigationManager, IJSRuntime jSRuntime)
  {


    [EffectMethod]
    public async Task HandleLoadProductsAction(LoadProductsAction action, IDispatcher dispatcher)
    {
      try
      {
        var products = productsRepository.GetProducts();
        dispatcher.Dispatch(LoadProductsSuccess(products));
      }
      catch (Exception ex)
      {
        dispatcher.Dispatch(LoadProductsFailure(ex.Message));
      }
    }

  }
}
