using Microsoft.Extensions.Configuration;
using Workshop.ViewModels;

namespace Workshop.Datasource
{
  public class ProductsRepository : IProductsRepository
  {

    private IList<Product> products = [];

    public ProductsRepository(IConfiguration configuration)
    {
      products = new List<Product>
      {
        new Product { Id = 1, Name = "Product 1", Price = 100 },
        new Product { Id = 2, Name = "Product 2", Price = 200 },
        new Product { Id = 3, Name = "Product 3", Price = 300 },
        new Product { Id = 4, Name = "Product 4", Price = 400 },
        new Product { Id = 5, Name = "Product 5", Price = 500 },
      };
    }

    public void AddProduct(ProductViewModel product)
    {
      products.Add(new Product
      {
        Id = products.Max(e => e.Id) + 1,
        Name = product.Name,
        Price = product.Price
      });
    }

    public ProductListViewModel GetProducts()
    {
      var viewModel = new ProductListViewModel()
      {
        Products = products.Select(p => new ProductViewModel
        {
          Id = p.Id,
          Name = p.Name,
          Price = p.Price
        }).ToList(),
      };
      return viewModel;
    }

  }
}
