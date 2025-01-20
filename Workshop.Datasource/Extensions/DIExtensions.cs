using Workshop.Datasource;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class DIExtensions
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<IProductsRepository, ProductsRepository>();
      return services;
    }
  }
}
