using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.UnitTests.Library.ProductsComponent
{
  [TestClass]
  public class ProductsTestContext : ProductsTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      // Arrange

      // Act

      // Assert
      productRepositoryMock.Verify(x => x.GetProduct(1), Moq.Times.Never());
    }
  }
}
