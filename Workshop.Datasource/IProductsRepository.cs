
using Workshop.ViewModels;

namespace Workshop.Datasource
{
  public interface IProductsReadOnlyRepository
  {
    ProductListViewModel GetProducts();

    ProductViewModel? GetProduct(int id);

  }

  public interface IProductsRepository : IProductsReadOnlyRepository
  {
    
    void AddProduct(ProductViewModel product);

    void UpdateProduct(ProductViewModel product);

    bool DeleteProduct(int id);
  }
}