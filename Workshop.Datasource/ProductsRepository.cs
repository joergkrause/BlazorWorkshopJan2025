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

    public void UpdateProduct(ProductViewModel product)
    {
      ArgumentNullException.ThrowIfNull(product, nameof(product));

      DeleteProduct(product.Id);
      AddProduct(product);
    }

    public bool DeleteProduct(int id)
    {
      ArgumentOutOfRangeException.ThrowIfLessThan(id, 1, nameof(id));

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
      ArgumentOutOfRangeException.ThrowIfLessThan(id, 1, nameof(id));

      return products.SingleOrDefault(p => p.Id == id);
    }

    public ProductListViewModel GetProducts()
    {
      return new ProductListViewModel(products);
    }

    public void AddProduct(ProductViewModel product)
    {
      ArgumentNullException.ThrowIfNull(product, nameof(product));

      product.Id = products.Max(e => e.Id) + 1;
      products.Add(product);
    }
  }
}
