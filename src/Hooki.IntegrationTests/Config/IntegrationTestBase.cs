using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Discord.Models;
using Hooki.Utilities;
using IntegrationTests.Enums;
using Microsoft.Extensions.Configuration;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

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
        
        var json = JsonHelper.Serialize(payload);
        
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync(url, content);
    }
    
    protected async Task<HttpResponseMessage> SendWebhookPayloadWithFilesAsync(PlatformTypes platform, object payload, MultipartFormDataContent? content)
    {
        var url = GetWebhookUrl(platform);

        // If we received content, send a POST request using it
        if (content is not null) return await _httpClient.PostAsync(url, content);
        
        // If we didn't receive content and the platform is Discord then need to create the MultipartContent
        if (platform is PlatformTypes.Discord && payload is DiscordWebhookPayload discordPayload)
        {
            return await _httpClient.PostAsync(url, discordPayload.MultipartContent);
        }
        
        // If we didn't receive content and the platform is not Discord then generate the POST body with the standard implementation
        var json = JsonHelper.Serialize(payload);
        var payloadContent = new StringContent(json, Encoding.UTF8, "application/json");

        return await _httpClient.PostAsync(url, payloadContent);
    }
}