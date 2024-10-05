using FluentAssertions;
using Hooki.Discord.Builders;
using Hooki.Discord.Enums;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class AllowedMentionBuilderTests
{
    [Fact]
    public void Build_WithAllProperties_ReturnsCorrectAllowedMention()
    {
        // Arrange
        var builder = new AllowedMentionBuilder()
            .AddParse(AllowedMentionTypes.Roles)
            .AddParse(AllowedMentionTypes.Users)
            .AddRole("123456")
            .AddUser("789012")
            .WithRepliedUser(true);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Parse.Should().Contain(AllowedMentionTypes.Roles);
        result.Parse.Should().Contain(AllowedMentionTypes.Users);
        result.Roles.Should().Contain("123456");
        result.Users.Should().Contain("789012");
        result.RepliedUser.Should().BeTrue();
    }

    [Fact]
    public void Build_WithNoProperties_ReturnsEmptyAllowedMention()
    {
        // Arrange
        var builder = new AllowedMentionBuilder();

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