using System.Net;
using IntegrationTests.Config;
using Hooki.Discord.Extensions;
using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;
using IntegrationTests.Enums;
using IntegrationTests.Extensions;

namespace IntegrationTests;

public class DiscordTests(HttpClientFixture fixture) : IntegrationTestBase(fixture)
{
    private const string HookiLogoFileName = "hooki-icon.png";
    private const string DiscordSnowflakeId = "1282373368523395145"; // General text channel ID in Alertu discord server

    [Fact]
    public async Task When_Sending_A_Simple_Discord_Webhook_Payload_Then_Return_204()
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
    
    [Fact]
    public async Task When_Sending_Discord_Webhook_Payload_With_Only_An_Embed_Then_Return_204()
    {
        // Arrange
        var payload = DiscordWebhookPayloadExtensions.BuildDiscordWebhookPayload(builder => builder
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
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Content_Then_Return_204()
    {
        // Arrange
        var payload = DiscordWebhookPayloadExtensions.BuildDiscordWebhookPayload(builder => builder
            .WithContent("This is a test discord webhook payload")
        );
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_An_Attachment_Then_Return_200()
    {
        // Arrange
        var attachment = new Attachment
        {
            Id = DiscordSnowflakeId,
            FileName = HookiLogoFileName,
            ContentType = "image/png",
            Height = 128,
            Width = 128,
            Size = 19251,
            Content = ResourceReaderExtensions.GetEmbeddedResourceBytes("IntegrationTests.hooki-icon.png")
        };

        var payload = new DiscordWebhookPayload
        {
            Content = "This is a test discord webhook payload",
            Attachments = new List<Attachment> { attachment }
        };
        
        // Act
        var response = await SendWebhookPayloadWithFilesAsync(PlatformTypes.Discord, payload, payload.MultipartContent!);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Files_And_An_Attachment_Then_Return_200()
    {
        // Arrange
        var payload = DiscordWebhookPayloadExtensions.BuildDiscordWebhookPayload(builder => builder
            .AddEmbed(embed => embed
                .WithTitle("Test Embed Title")
                .WithDescription("Test Embed Description")
                .WithThumbnail($"attachment://{HookiLogoFileName}")
                .WithImage($"attachment://{HookiLogoFileName}")
            )
            .WithContent("Test Content")
            .AddAttachment(new Attachment
            {
                Id = DiscordSnowflakeId,
                Description = "Hooki Logo",
                FileName = "hooki-icon.png",
                Height = 128,
                Width = 128
            })
            .AddFile(new FileContent
            {
                SnowflakeId = DiscordSnowflakeId,
                FileName = HookiLogoFileName,
                ContentType = "image/png",
                FileContents = ResourceReaderExtensions.GetEmbeddedResourceBytes($"IntegrationTests.{HookiLogoFileName}")
            }));
        
        // Act
        var response = await SendWebhookPayloadWithFilesAsync(PlatformTypes.Discord, payload, payload.MultipartContent!);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

