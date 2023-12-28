using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace Client.API;

public class ReviewersTaskAPI
{
    private readonly IOptions<AppSettings> _options;
    public ReviewersTaskAPI(IOptions<AppSettings> options)
    {
        _options = options;
    }

    public async Task<ulong?> CreateAsync(CreateReviewersTaskWebRequest request)
    {
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync($"{_options.Value.Url}/api/tasks", request);

        if (response.IsSuccessStatusCode)
        {
            // TODO: make a normal response type
            return ulong.TryParse(await response.Content.ReadAsStringAsync(), out var result) ? result : null;
        }

        return null;
    }
    
    public async Task<ReviewersTaskWebResult> GetByIdAsync(ulong id)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"{_options.Value.Url}/api/tasks/{id}");

        if (response.IsSuccessStatusCode)
        {
            var webResult = await response.Content.ReadFromJsonAsync<ReviewersTaskWebResult>();
            return webResult;
        }

        return null;
    }
}