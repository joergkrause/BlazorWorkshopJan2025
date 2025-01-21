using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using Workshop.ViewModels;

namespace Workshop.Datasource
{
  public class ProductsRepository : IProductsRepository
  {
    private ObservableCollection<ProductViewModel> products;

    public ProductsRepository(IConfiguration configuration)
    {
      products = new ()
            {
                new ProductViewModel { Id = 1, Name = "Product 1", Price = 100 },
                new ProductViewModel { Id = 2, Name = "Product 2", Price = 200 },
                new ProductViewModel { Id = 3, Name = "Product 3", Price = 300 },
                new ProductViewModel { Id = 4, Name = "Product 4", Price = 400 },
                new ProductViewModel { Id = 5, Name = "Product 5", Price = 500 },
            };
    }

    public void AddProduct(ProductViewModel product)
    {
      product.Id = products.Max(e => e.Id) + 1;
      products.Add(product);
    }

    public bool DeleteProduct(int id)
    {
      var product = products.SingleOrDefault(p => p.Id == id);
      if (product == null)
      {
        return false;
      }
      products.Remove(product);
      return true;
    }

    public ProductViewModel? GetProduct(int id)
    {
      return products.SingleOrDefault(p => p.Id == id);
    }

    public ProductListViewModel GetProducts()
    {
      return new ProductListViewModel(products);
    }
  }
}
