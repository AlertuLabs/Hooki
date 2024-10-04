using System.Text;
using Hooki.Discord.Models;
using Hooki.Utilities;
using IntegrationTests.Enums;

namespace IntegrationTests.Config;

public abstract class IntegrationTestBase : IClassFixture<HttpClientFixture>
{
    private readonly HttpClient _httpClient;

    private readonly string _discordWebhookUrl;
    private readonly string _microsoftTeamsWebhookUrl;
    private readonly string _slackWebhookUrl;
    
    protected const string DiscordSnowflakeId = "1282373368523395145"; // General text channel ID in Alertu discord server
    protected readonly string TestImageFileName;
    protected readonly string TestImageCloudUrl;
    protected readonly string PipedreamUrl;
    
    protected IntegrationTestBase(HttpClientFixture fixture)
    {
        _httpClient = fixture.Client;
        var configuration = fixture.Configuration;

        TestImageFileName = configuration["TEST_IMAGE_FILE_NAME"] 
                            ?? configuration["TestImageFileName"] 
                            ?? throw new InvalidOperationException("Missing TestImageFileName in environment variables");
        
        TestImageCloudUrl = configuration["TEST_IMAGE_CLOUD_URL"] 
                            ?? configuration["TestImageCloudUrl"] 
                            ?? throw new InvalidOperationException("Missing TestImageCloudUrl in environment variables");
        
        PipedreamUrl = configuration["TEST_PIPEDREAM_URL"] 
                       ?? configuration["PipedreamUrl"] 
                       ?? throw new InvalidOperationException("Missing PipedreamUrl in environment variables");
        
        _discordWebhookUrl = configuration["TEST_DISCORD_WEBHOOK_URL"]
                            ?? configuration["WebhookUrls:Discord"]
                            ?? throw new InvalidOperationException("Missing Webhook URL for Discord in environment variables.");
        
        _microsoftTeamsWebhookUrl = configuration["TEST_MICROSOFT_TEAMS_WEBHOOK_URL"]
                            ?? configuration["WebhookUrls:MicrosoftTeams"]
                            ?? throw new InvalidOperationException("Missing Webhook URL for Discord in environment variables.");
        
        _slackWebhookUrl = configuration["TEST_SLACK_WEBHOOK_URL"]
                            ?? configuration["WebhookUrls:Slack"]
                            ?? throw new InvalidOperationException("Missing Webhook URL for Discord in environment variables.");
    }

    private string GetWebhookUrl(PlatformTypes platform)
    {
        return platform switch
        {
            PlatformTypes.Discord => _discordWebhookUrl,
            PlatformTypes.MicrosoftTeams => _microsoftTeamsWebhookUrl,
            PlatformTypes.Slack => _slackWebhookUrl,
            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
        };
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