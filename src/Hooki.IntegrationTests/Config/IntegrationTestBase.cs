using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using IntegrationTests.Enums;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Config;

public abstract class IntegrationTestBase : IClassFixture<HttpClientFixture>
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    protected IntegrationTestBase(HttpClientFixture fixture)
    {
        _httpClient = fixture.Client;
        _configuration = fixture.Configuration;
    }

    private string GetWebhookUrl(PlatformTypes platform)
    {
        return _configuration[$"WebhookUrls:{platform}"]
               ?? throw new InvalidOperationException($"Webhook URL for {platform} not found.");
    }
    
    protected async Task<HttpResponseMessage> SendWebhookPayloadAsync(PlatformTypes platform, object payload)
    {
        var url = GetWebhookUrl(platform);
        
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
        
        var json = JsonSerializer.Serialize(payload, options);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync(url, content);
    }
}