using FluentAssertions;
using Hooki.Discord.Builders;
using Hooki.Discord.Enums;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class DiscordWebhookPayloadBuilderTests
{
    [Fact]
    public void Build_WithAllProperties_ReturnsCorrectPayload()
    {
        // Arrange
        var builder = new DiscordWebhookPayloadBuilder()
            .WithContent("Test content")
            .WithUsername("TestUser")
            .WithAvatarUrl("http://example.com/avatar.png")
            .WithTts(true)
            .AddEmbed(e => e.WithTitle("Test Embed"))
            .WithAllowedMentions(am => am.AddParse(AllowedMentionTypes.Users))
            .AddComponent(new { type = 1, style = 1, label = "Click me" })
            .AddFile(new FileContent { SnowflakeId = "123", FileName = "test.txt", FileContents = new byte[] { 1, 2, 3 }, ContentType = "text/plain" })
            .WithPayloadJson("{\"key\":\"value\"}")
            .AddAttachment(new Attachment { Id = "456", FileName = "attachment.png" })
            .WithFlags(64)
            .WithThreadName("Test Thread")
            .AddAppliedTag("TestTag")
            .WithPoll(p => p.WithQuestion(q => q.WithText("Test Question")).AddAnswer(a => a.WithAnswerId(1).WithPollMedia(m => m.WithText("Test Media"))));

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Content.Should().Be("Test content");
        result.Username.Should().Be("TestUser");
        result.AvatarUrl.Should().Be("http://example.com/avatar.png");
        result.Tts.Should().BeTrue();
        result.Embeds.Should().ContainSingle();
        result.AllowedMentions.Should().NotBeNull();
        result.Components.Should().ContainSingle();
        result.Files.Should().ContainSingle();
        result.PayloadJson.Should().Be("{\"key\":\"value\"}");
        result.Attachments.Should().ContainSingle();
        result.Flags.Should().Be(64);
        result.ThreadName.Should().Be("Test Thread");
        result.AppliedTags.Should().ContainSingle();
        result.Poll.Should().NotBeNull();
        result.Poll?.Question.Text.Should().Be("Test Question");
        result.Poll?.Answers.Should()
            .ContainSingle(answer => answer.AnswerId == 1 && answer.PollMedia.Text == "Test Media");
    }

    [Fact]
    public void Build_WithNoProperties_ReturnsEmptyPayload()
    {
        // Arrange
        var builder = new DiscordWebhookPayloadBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Content.Should().BeNull();
        result.Username.Should().BeNull();
        result.AvatarUrl.Should().BeNull();
        result.Tts.Should().BeNull();
        result.Embeds.Should().BeNull();
        result.AllowedMentions.Should().BeNull();
        result.Components.Should().BeNull();
        result.Files.Should().BeNull();
        result.PayloadJson.Should().BeNull();
        result.Attachments.Should().BeNull();
        result.Flags.Should().BeNull();
        result.ThreadName.Should().BeNull();
        result.AppliedTags.Should().BeNull();
        result.Poll.Should().BeNull();
    }
}