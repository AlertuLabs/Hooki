using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Models.Blocks;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class DividerBlockBuilderTests
{
    [Fact]
    public void Build_Returns_Valid_DividerBlock()
    {
        // Arrange
        var builder = new DividerBlockBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<DividerBlock>();
        result.BlockId.Should().BeNull();
    }
    
    [Fact]
    public void Build_Without_BlockId_Returns_DividerBlock_With_Null_BlockId()
    {
        // Arrange
        var builder = new DividerBlockBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<DividerBlock>();
        result.BlockId.Should().BeNull();
    }
}