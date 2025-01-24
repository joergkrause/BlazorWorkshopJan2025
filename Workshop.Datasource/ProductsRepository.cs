using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using Workshop.ViewModels;

namespace Workshop.Datasource
{
  public sealed class ProductsRepository : BaseRepository, IProductsRepository
  {
    private ObservableCollection<ProductViewModel> products = [];

    public ProductsRepository(IConfiguration configuration)
    {
     
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

      product.Id = products.Any() ? products.Max(e => e.Id) + 1 : 1;
      products.Add(product);
    }
  }
}
