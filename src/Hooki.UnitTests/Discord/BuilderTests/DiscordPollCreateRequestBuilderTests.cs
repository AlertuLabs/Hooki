using FluentAssertions;
using Hooki.Discord.Builders;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class DiscordPollCreateRequestBuilderTests
{
    [Fact]
    public void Build_With_All_Properties_Returns_Expected_Result()
    {
        // Arrange
        var builder = new DiscordPollCreateRequestBuilder()
            .WithQuestion(q => q.WithText("Test Question"))
            .AddAnswer(a => a.WithAnswerId(1).WithPollMedia(m => m.WithText("Answer 1").WithEmoji(e => e.WithName("1️⃣").WithId("️123"))))
            .AddAnswer(a => a.WithAnswerId(2).WithPollMedia(m => m.WithText("Answer 2").WithEmoji(e => e.WithName("2️⃣").WithId("123"))))
            .AllowMultiSelect()
            .WithDuration(24)
            .WithLayoutType(1);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Question.Should().NotBeNull();
        result.Question.Text.Should().Be("Test Question");
        result.Question.Emoji.Should().BeNull();
        result.Answers.Should().HaveCount(2);
        result.Duration.Should().Be(24);
        result.AllowMultiSelect.Should().BeTrue();
        result.LayoutType.Should().Be(1);
    }
    
    [Fact]
    public void Build_With_Minimal_Properties_Returns_Expected_Result()
    {
        // Arrange
        var builder = new DiscordPollCreateRequestBuilder();

        // Act
        Assert.Throws<InvalidOperationException>(() => builder.Build());

        builder
            .WithQuestion(q => q.WithText("Test Question"));
        
        Assert.Throws<InvalidOperationException>(() => builder.Build());

        builder
            .AddAnswer(a =>
                a.WithAnswerId(1).WithPollMedia(m => m.WithText("Answer 1").WithEmoji(e => e.WithName("1️⃣"))))
            .AddAnswer(a =>
                a.WithAnswerId(2).WithPollMedia(m => m.WithText("Answer 2").WithEmoji(e => e.WithName("2️⃣"))));

        var result = builder.Build();
        
        // Assert
        result.LayoutType.Should().BeNull();
        result.Duration.Should().BeNull();
        result.AllowMultiSelect.Should().BeNull();
    }
}