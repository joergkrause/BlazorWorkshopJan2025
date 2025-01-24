using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Datasource;

namespace Workshop.UnitTests.Library
{
  public abstract class BunitTestContext : TestContextWrapper
  {

    protected Mock<IProductsRepository> productRepositoryMock;

    public virtual void Setup() => TestContext = Init();

    public virtual void Teardown() => TestContext?.Dispose();

    protected virtual Bunit.TestContext Init() {
      var context = new Bunit.TestContext();

      productRepositoryMock = new Mock<IProductsRepository>();
      productRepositoryMock.Setup(x => x.GetProduct(1)).Returns(new ViewModels.ProductViewModel { Id = 1, Name = "Test", Price = 99M });
      productRepositoryMock.Setup(x => x.GetProduct(It.IsAny<int>())).Returns<int>((id) => new ViewModels.ProductViewModel { Id = id, Name = "Test", Price = 99M });

      context.Services.AddTransient<IProductsRepository>((sp) => productRepositoryMock.Object);

      return context;
    }
  }
}
