using Fluxor;
using System.Reflection;

namespace Workshop.BlazorApp.Components.Stores.Extensions
{
  public static class DependencyInjectionExtention
  {
    public static IServiceCollection AddStores(this IServiceCollection services, params Assembly[] assemblies)
    {
      services.AddFluxor(options =>
      {
        options.ScanAssemblies(assemblies.First(), assemblies);
      });
      foreach (var assembly in assemblies)
      {
        var types = assembly.GetTypes().Where(t => t.GetCustomAttribute<SelectorAttribute>() != null);
        foreach (var type in types)
        {
          services.AddTransient(type);
        }
      }

      return services;
    }
  }
}
