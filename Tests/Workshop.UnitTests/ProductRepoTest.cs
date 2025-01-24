using Microsoft.Extensions.Configuration;
using Moq;
using Workshop.Datasource;
using Workshop.ViewModels;

namespace Workshop.UnitTests
{
  [TestClass]
  public sealed class ProductRepoTest
  {

    private ProductsRepository _repository;
    List<ProductViewModel> products = new()
            {
                new ProductViewModel { Id = 1, Name = "Product 1", Price = 100 },
                new ProductViewModel { Id = 2, Name = "Product 2", Price = 200 },
                new ProductViewModel { Id = 3, Name = "Product 3", Price = 300 },
                new ProductViewModel { Id = 4, Name = "Product 4", Price = 400 },
                new ProductViewModel { Id = 5, Name = "Product 5", Price = 500 },
            };

    [TestInitialize]
    public void TestInit()
    {
      // variante 1 - no data
      // var configuration = new ConfigurationBuilder().Build();

      // variante 2 - fixed data
      var section = new Mock<IConfigurationSection>();
      section.Setup(x => x["ConnectionString"]).Returns("Server=.;Database=Workshop;Trusted_Connection=True;");
      var configuration = new Mock<IConfiguration>();
      configuration.Setup(x => x.GetSection("ConnectionStrings")).Returns(section.Object);

      _repository = new ProductsRepository(configuration.Object);

      foreach (var product in products)
      {
        _repository.AddProduct(product);
      }
    }

    [TestCleanup]
    public void TestCleanup()
    {
      // This method is called after each test method.
    }

    [TestMethod("Add product success")]
    public void AddProduct_ShouldAddproduct()
    {
      // Arrange (Setup)
      var newProduct = new ProductViewModel { Name = "Product 6", Price = 600 };

      // Act (Execute)
      _repository.AddProduct(newProduct);
      var products = _repository.GetProducts();

      // Assert (Verify)
      Assert.IsNotNull(products);
      Assert.IsTrue(products.Products.Count == 6);
      Assert.AreEqual(600, products.Products[5].Price);

    }

    [TestMethod("Update product success")]
    public void UpdateProduct_ShouldUpdateExistingProduct()
    {
      // Arrange (Setup)
      var product = _repository.GetProduct(1);
      product.Name = "Product 1 Updated";
      product.Price = 101;

      // Act (Execute)
      _repository.UpdateProduct(product);
      var updatedProduct = _repository.GetProduct(1);

      // Assert (Verify)
      Assert.IsNotNull(updatedProduct);
      Assert.AreEqual("Product 1 Updated", updatedProduct.Name);
      Assert.AreEqual(101, updatedProduct.Price);
    }

    [TestMethod("Delete product success")]
    public void DeleteProduct_ShouldRemoveProduct()
    {
      // Arrange (Setup)
      var product = _repository.GetProduct(1);
      // Act (Execute)
      var result = _repository.DeleteProduct(1);
      var deletedProduct = _repository.GetProduct(1);
      // Assert (Verify)
      Assert.IsTrue(result);
      Assert.IsNull(deletedProduct);
    }

    [TestMethod("Get product success")]
    public void GetProducts_ShouldReturnAllProducts()
    {
      // Arrange (Setup)
      // Act (Execute)
      var products = _repository.GetProducts();
      // Assert (Verify)
      Assert.IsNotNull(products);
      Assert.IsTrue(products.Products.Count == 5);
    }

  }
}
