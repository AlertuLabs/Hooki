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
    public void Build_With_BlockId_Returns_DividerBlock_With_Correct_BlockId()
    {
        // Arrange
        var builder = new DividerBlockBuilder().WithBlockId("test-divider-block");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<DividerBlock>();
        result.BlockId.Should().Be("test-divider-block");
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

    [Fact]
    public void WithBlockId_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new DividerBlockBuilder();

        // Act
        var result = builder.WithBlockId("test-divider-block");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
    {
        // Arrange
        var builder = new DividerBlockBuilder().WithBlockId("test-divider-block");

        // Act
        var result1 = builder.Build();
        var result2 = builder.Build();

        // Assert
        result1.Should().NotBeSameAs(result2);
        result1.BlockId.Should().Be(result2.BlockId);
    }
}