
using Workshop.ViewModels;

namespace Workshop.Datasource
{
  public interface IProductsRepository
  {
    ProductListViewModel GetProducts();

    void AddProduct(ProductViewModel product);

    ProductViewModel? GetProduct(int id);

    bool DeleteProduct(int id);
  }
}