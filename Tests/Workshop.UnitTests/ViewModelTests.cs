using System.Globalization;
using Workshop.ViewModels;

namespace Workshop.UnitTests;

[TestClass]
public class ViewModelTests
{
    [TestMethod]
    public void ProductViewModel_ShouldConvertPriceString_German()
    {
    // Arrange
    var product = new ProductViewModel() {  Price = 123.45M };
    var originalCulture = Thread.CurrentThread.CurrentCulture;
    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

    try
    {
      // Act
      var result = product.PriceString;

      // Assert
      Assert.AreEqual("123,45 €", result);
    }
    finally
    {
      Thread.CurrentThread.CurrentCulture = originalCulture;
    }
  }

  [TestMethod]
  public void ProductViewModel_ShouldConvertPriceString_English()
  {
    // Arrange
    var product = new ProductViewModel() { Price = 123.45M };
    var originalCulture = Thread.CurrentThread.CurrentCulture;
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

    try
    {
      // Act
      var result = product.PriceString;

      // Assert
      Assert.AreEqual("123.45 €", result);
    }
    finally
    {
      Thread.CurrentThread.CurrentCulture = originalCulture;
    }
  }

  [TestMethod]
  public void ProductViewModel_ShouldReturnEditLink()
  {
    // Arrange
    var product = new ProductViewModel() { Id = 123 };
    // Act
    var result = product.EditLink;
    // Assert
    Assert.AreEqual("/products/123", result);
  }

  [TestMethod]
  public void ProductViewModel_ShouldReturnProductEditViewModel()
  {
    // Arrange
    var product = new ProductViewModel() { Id = 123, Name = "Product 123", Price = 123.45M };
    // Act
    var result = product.GetProductEditViewModel();
    // Assert
    Assert.AreEqual(123, result.Id);
    Assert.AreEqual("Product 123", result.Name);
    Assert.AreEqual(123.45M, result.Price);
  }

}

// Arrange
// Act
// Assert
