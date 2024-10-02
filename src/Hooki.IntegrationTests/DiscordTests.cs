using System.Net;
using IntegrationTests.Config;
using Hooki.Discord.Extensions;
using IntegrationTests.Enums;

namespace IntegrationTests;

public class DiscordTests : IntegrationTestBase
{
    public DiscordTests(HttpClientFixture fixture) : base(fixture) { }
    
    [Fact]
    public async Task SendDiscordWebhook_SimpleMessage_ReturnsSuccessStatusCode()
    {
        // Arrange
        var payload = DiscordWebhookPayloadExtensions.BuildDiscordWebhookPayload(builder => builder
            .WithUsername("Alertu Webhook")
            .WithAvatarUrl("https://res.cloudinary.com/deknqhm9k/image/upload/v1727617327/Social2_bvec22.png")
            .AddEmbed(embed => embed
                .WithAuthor("Alertu", "https://alertu.io", "https://res.cloudinary.com/deknqhm9k/image/upload/v1727617327/Social2_bvec22.png")
                .WithTitle("Azure Metric Alert triggered")
                .WithDescription("[**View in Alertu**](https://alertu.io) | [**View in Azure**](https://portal.azure.com)")
                .WithColor(959721)
                .AddField("Summary", "Test Summary", false)
                .AddField("Organization Name", "Test Organization", true)
                .AddField("Project Name", "Test Project", true)
                .AddField("Cloud Provider", "Azure", true)
                .AddField("Resources", string.Join(", ", "test-redis", "test-postgreSQL"), true)
                .AddField("Severity", "Critical", true)
                .AddField("Status", "Open", true)
                .AddField("Triggered At", DateTimeOffset.UtcNow.ToString("f"), true)
                .AddField("Resolved At", DateTimeOffset.UtcNow.AddMinutes(5).ToString("f"), true)
            )
        );

        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}