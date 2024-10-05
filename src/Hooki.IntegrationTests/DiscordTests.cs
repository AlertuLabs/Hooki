using System.Net;
using Hooki.Discord.Builders;
using IntegrationTests.Config;
using Hooki.Discord.Models.BuildingBlocks;
using IntegrationTests.Enums;
using IntegrationTests.Extensions;

namespace IntegrationTests;

public class DiscordTests(HttpClientFixture fixture) : IntegrationTestBase(fixture)
{
    [Fact]
    public async Task When_Sending_A_Simple_Discord_Webhook_Payload_Then_Return_204()
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .WithUsername("Alertu Webhook")
            .WithAvatarUrl("https://res.cloudinary.com/deknqhm9k/image/upload/v1727617327/Social2_bvec22.png")
            .WithContent("This is a test discord webhook payload")
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
                .AddField("Resolved At", DateTimeOffset.UtcNow.AddMinutes(5).ToString("f"), true))
            .Build();

        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Discord_Webhook_Payload_With_Only_An_Embed_Then_Return_204()
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .WithContent("This is a test discord webhook payload")
            .AddEmbed(embed => embed
                .WithAuthor("Alertu", "https://alertu.io", TestImageCloudUrl)
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
                .AddField("Resolved At", DateTimeOffset.UtcNow.AddMinutes(5).ToString("f"), true))
            .Build();

        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Content_Then_Return_204()
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .WithContent("This is a test discord webhook payload")
            .Build();
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_An_Attachment_Then_Return_200()
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .AddAttachment(new Attachment
            {
                Id = DiscordSnowflakeId,
                FileName = TestImageFileName,
                ContentType = "image/png",
                Height = 128,
                Width = 128,
                Size = 19251,
                Content = ResourceReaderExtensions.GetEmbeddedResourceBytes("IntegrationTests.hooki-icon.png")
            })
            .WithContent("This is a test discord webhook payload")
            .Build();
        
        // Act
        var response = await SendWebhookPayloadWithMultipartFormDataContentAsync(PlatformTypes.Discord, payload, payload.MultipartContent!);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Files_And_An_Attachment_Then_Return_200()
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .AddEmbed(embed => embed
                .WithTitle("Test Embed Title")
                .WithDescription("Test Embed Description")
                .WithThumbnail($"attachment://{TestImageFileName}")
                .WithImage($"attachment://{TestImageFileName}")
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
                FileName = TestImageFileName,
                ContentType = "image/png",
                FileContents = ResourceReaderExtensions.GetEmbeddedResourceBytes($"IntegrationTests.{TestImageFileName}")
            })
            .Build();
        
        // Act
        var response = await SendWebhookPayloadWithMultipartFormDataContentAsync(PlatformTypes.Discord, payload, payload.MultipartContent!);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Theory]
    [InlineData(24, false)]
    [InlineData(48, true)]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Poll_With_1_Answer_Then_Return_204(int duration, bool isMultiSelect)
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .WithPoll(poll => 
                poll.WithQuestion(pollmedia => 
                    pollmedia.WithText("Penguins"))
                    .WithDuration(duration)
                    .AllowMultiSelect(isMultiSelect)
                    .AddAnswer(pollAnswer =>
                        pollAnswer.WithPollMedia(pollMedia =>
                            pollMedia.WithText("Penguins emojis are the best!")
                                .WithEmoji(emoji => emoji.WithName("🐧")))
                            .WithAnswerId(1)))
            .Build();
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Theory]
    [InlineData(24, false)]
    [InlineData(48, true)]
    public async Task When_Sending_Minimal_Discord_Webhook_Payload_With_Poll_With_Multiple_Answers_Then_Return_204(int duration, bool isMultiSelect)
    {
        // Arrange
        var payload = new DiscordWebhookPayloadBuilder()
            .WithPoll(poll => 
                poll.WithQuestion(pollmedia => 
                        pollmedia.WithText("What is your favorite TV show?"))
                    .WithDuration(duration)
                    .AllowMultiSelect(isMultiSelect)
                    .AddAnswer(pollAnswer =>
                        pollAnswer.WithPollMedia(pollMedia =>
                                pollMedia.WithText("Penguin")
                                    .WithEmoji(emoji => emoji.WithName("🐧")))
                            .WithAnswerId(1)).AddAnswer(pollAnswer =>
                        pollAnswer.WithPollMedia(pollMedia =>
                                pollMedia.WithText("Game of Thrones")
                                    .WithEmoji(emoji => emoji.WithName("❄️")))
                            .WithAnswerId(1))
                    .AddAnswer(pollAnswer =>
                        pollAnswer.WithPollMedia(pollMedia =>
                                pollMedia.WithText("Breaking bad")
                                    .WithEmoji(emoji => emoji.WithName("🧪")))
                            .WithAnswerId(1)))
            .Build();
        
        // Act
        var response = await SendWebhookPayloadAsync(PlatformTypes.Discord, payload);

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}

