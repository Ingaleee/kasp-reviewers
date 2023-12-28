using Environment;
using Kasp1_Review;
using Kasp1_Review.Abstractions;
using Kasp1_Review.Readers;
using Kasp1_Review.Src;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Domain;
using Tasks.IoC;

namespace Tasks;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerDocument();
        services.AddCors();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AssemblyProvider.All));
        services.AddAutoMapper(AssemblyProvider.All);
        
        services.AddSingleton<IRulesReader, YamlRulesReader>();
        services.AddSingleton<DefaultReviewersCollector>();


        services.WithMemoryDomain<MemoryApplicationContext>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(_ => _.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        app.UseRouting();
        
        app.UseEndpoints(b => b.MapControllers());
        
        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}