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
        await Task.Delay(5000);
        var products = productsRepository.GetProducts();
        dispatcher.Dispatch(LoadProductsSuccess(products));
      }
      catch (Exception ex)
      {
        dispatcher.Dispatch(LoadProductsFailure(ex.Message));
      }
    }

    [EffectMethod]
    public async Task HandleSaveProductAction(SaveProductAction action, IDispatcher dispatcher)
    {
      try
      {
        await Task.Delay(5000);
        productsRepository.AddProduct(action.Product.GetProductViewModel());
        
        dispatcher.Dispatch(SaveProductSuccess(action.Product.GetProductViewModel()));
        dispatcher.Dispatch(MustSaveChange(false));

        navigationManager.NavigateTo("/products");
      }
      catch (Exception ex)
      {
        dispatcher.Dispatch(SaveProductFailure(ex.Message));
      }
    }


  }
}
