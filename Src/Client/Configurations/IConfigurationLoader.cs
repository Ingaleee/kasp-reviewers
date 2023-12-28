using Microsoft.Extensions.Configuration;

namespace Client;

public interface IConfigurationLoader
{
    Task<IConfiguration> LoadOrCreateAsync(IConfigurationBuilder builder);
}