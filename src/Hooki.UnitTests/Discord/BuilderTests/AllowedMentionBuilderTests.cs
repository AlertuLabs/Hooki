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
        Assert.NotNull(result);
        Assert.Contains(AllowedMentionTypes.Roles, result.Parse);
        Assert.Contains(AllowedMentionTypes.Users, result.Parse);
        Assert.Contains("123456", result.Roles);
        Assert.Contains("789012", result.Users);
        Assert.True(result.RepliedUser);
    }

    [Fact]
    public void Build_WithNoProperties_ReturnsEmptyAllowedMention()
    {
        // Arrange
        var builder = new AllowedMentionBuilder();

        // Act
        var result = builder.Build();

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Parse);
        Assert.Null(result.Roles);
        Assert.Null(result.Users);
        Assert.Null(result.RepliedUser);
    }
}