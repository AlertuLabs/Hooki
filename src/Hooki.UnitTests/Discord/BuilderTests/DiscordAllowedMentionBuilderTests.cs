using FluentAssertions;
using Hooki.Discord.Builders;
using Hooki.Discord.Enums;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class DiscordAllowedMentionBuilderTests
{
    [Fact]
    public void Build_With_All_Properties_Returns_Correct_AllowedMention()
    {
        // Arrange
        var builder = new DiscordAllowedMentionBuilder()
            .AddParse(DiscordAllowedMentionType.Roles)
            .AddParse(DiscordAllowedMentionType.Users)
            .AddRole("123456")
            .AddUser("789012")
            .WithRepliedUser(true);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Parse.Should().Contain(DiscordAllowedMentionType.Roles);
        result.Parse.Should().Contain(DiscordAllowedMentionType.Users);
        result.Roles.Should().Contain("123456");
        result.Users.Should().Contain("789012");
        result.RepliedUser.Should().BeTrue();
    }

    [Fact]
    public void Build_With_No_Properties_Returns_Empty_AllowedMention()
    {
        // Arrange
        var builder = new DiscordAllowedMentionBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Parse.Should().BeNull();
        result.Roles.Should().BeNull();
        result.Users.Should().BeNull();
        result.RepliedUser.Should().BeNull();
    }
}