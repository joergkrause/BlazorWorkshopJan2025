using Workshop.ViewModels;

namespace Workshop.BlazorApp.Components.Stores.ProductsStore
{
  public static class ProductActions
  {
    public record LoadProductsAction();
    public record LoadProductsSuccessAction(ProductListViewModel Products);
    public record LoadProductsFailureAction(string Error);

    public record SaveProductAction(ProductEditViewModel Product) : ISaveAction;
    public record SaveProductSuccessAction(ProductViewModel Product) : ISaveAction;
    public record SaveProductFailureAction(string Error) : ISaveAction;

    public record EditProductAction(ProductViewModel Product);

    public static LoadProductsAction LoadProducts() => new();
    public static LoadProductsSuccessAction LoadProductsSuccess(ProductListViewModel products) => new(products);
    public static LoadProductsFailureAction LoadProductsFailure(string error) => new(error);

    public static SaveProductAction SaveProduct(ProductEditViewModel product) => new(product);
    public static SaveProductSuccessAction SaveProductSuccess(ProductViewModel product) => new(product);
    public static SaveProductFailureAction SaveProductFailure(string error) => new(error);

    public static EditProductAction EditProduct(ProductViewModel product) => new(product);
  }
}
