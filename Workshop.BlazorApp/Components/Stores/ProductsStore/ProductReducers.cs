using Fluxor;
using static Workshop.BlazorApp.Components.Stores.ProductsStore.ProductActions;

namespace Workshop.BlazorApp.Components.Stores.ProductsStore
{
  public static class ProductReducers
  {

    [ReducerMethod(typeof(LoadProductsAction))]
    public static ProductsState ReduceLoadProductsAction(ProductsState state)
    {
      return state with { IsLoading = true, Error = string.Empty };
    }

    [ReducerMethod]
    public static ProductsState ReduceLoadProductsSuccessAction(ProductsState state, LoadProductsSuccessAction action)
    {
      return state with { IsLoading = false, Products = action.Products };
    }

    [ReducerMethod]
    public static ProductsState ReduceLoadProductsFailureAction(ProductsState state, LoadProductsFailureAction action)
    {
      return state with { IsLoading = false, Error = action.Error };
    }

    [ReducerMethod]
    public static ProductsState ReduceSaveAction(ProductsState state, ISaveAction action)
    {
      return action switch
      {
        // TODO: model konvertieren
        SaveProductAction saveProductAction => state with { IsSaving = true, PreviousProduct = saveProductAction.Product.GetProductViewModel(), Error = string.Empty },
        SaveProductSuccessAction _ => state with { IsSaving = false, Error = string.Empty },
        SaveProductFailureAction saveProductFailureAction => state with { IsSaving = false, Error = saveProductFailureAction.Error },

        MustSaveChangeAction mustSaveChangeAction => state with { MustSave = mustSaveChangeAction.MustSave },

        _ => state
      };
    }
  }
}
