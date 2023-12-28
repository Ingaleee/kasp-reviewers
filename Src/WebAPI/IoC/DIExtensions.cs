using Microsoft.Extensions.DependencyInjection;
using Tasks.Domain;

namespace Tasks.IoC;

public static class DIExtensions
{
   public static IServiceCollection WithMemoryDomain<TContext>(this IServiceCollection services) where TContext: class
   {
      services.AddSingleton<TContext>();
      services.AddSingleton<IDbProvider<TContext>, MemoryDbProvider<TContext>>();

      return services;
   } 
}