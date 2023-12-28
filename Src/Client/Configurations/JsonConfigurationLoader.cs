using System.Text.Json;
using Environment;
using Microsoft.Extensions.Configuration;

namespace Client;

public class JsonConfigurationLoader : IConfigurationLoader
{
    public async Task<IConfiguration> LoadOrCreateAsync(IConfigurationBuilder builder)
    {
        var iExists = File.Exists(Variables.CONFIGURATIONS_PATH);
        if (!iExists)
        {
            await using var fileStream = new FileStream(Variables.CONFIGURATIONS_PATH, FileMode.OpenOrCreate);
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            await JsonSerializer.SerializeAsync(fileStream, AppSettings.Default, serializeOptions);
        }
        
        return new ConfigurationBuilder().AddJsonFile(Variables.CONFIGURATIONS_PATH).Build();
    }
}

public static class Configurator
{
    public static async Task<IConfiguration> LoadWithAsync<TLoader>()
        where TLoader : IConfigurationLoader, new()
    {
        var builder = new ConfigurationBuilder();
        return await new TLoader().LoadOrCreateAsync(builder);
    }
}
