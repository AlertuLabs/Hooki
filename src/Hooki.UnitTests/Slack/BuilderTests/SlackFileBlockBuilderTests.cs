using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Models.Blocks;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackFileBlockBuilderTests
{
    [Fact]
    public void Build_With_ExternalId_And_Source_Returns_Valid_FileBlock()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder()
            .WithExternalId("external-123")
            .WithSource("source-456");

        // Act
        var result = builder.Build() as SlackFileBlock;

        // Assert
        result.Should().NotBeNull();
        result!.ExternalId.Should().Be("external-123");
        result.Source.Should().Be("source-456");
        result.BlockId.Should().BeNull();
    }

    [Fact]
    public void Build_With_BlockId_ExternalId_And_Source_Returns_Valid_FileBlock()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder()
            .WithExternalId("external-123")
            .WithSource("source-456");

        // Act
        var result = builder.Build() as SlackFileBlock;

        // Assert
        result.Should().NotBeNull();
        result?.ExternalId.Should().Be("external-123");
        result?.Source.Should().Be("source-456");
    }

    [Fact]
    public void Build_Without_ExternalId_Returns_FileBlock_With_Default_ExternalId()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder()
            .WithSource("source-456");

        // Act
        var result = builder.Build() as SlackFileBlock;

        // Assert
        result.Should().NotBeNull();
        result!.ExternalId.Should().Be(default!);
        result.Source.Should().Be("source-456");
    }

    [Fact]
    public void Build_Without_Source_Returns_FileBlock_With_Default_Source()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder()
            .WithExternalId("external-123");

        // Act
        var result = builder.Build() as SlackFileBlock;

        // Assert
        result.Should().NotBeNull();
        result!.ExternalId.Should().Be("external-123");
        result.Source.Should().Be(default!);
    }

    [Fact]
    public void WithExternalId_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder();

        // Act
        var result = builder.WithExternalId("external-123");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithSource_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder();

        // Act
        var result = builder.WithSource("source-456");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
    {
        // Arrange
        var builder = new SlackFileBlockBuilder()
            .WithExternalId("external-123")
            .WithSource("source-456");

        // Act
        var result1 = builder.Build();
        var result2 = builder.Build();

        // Assert
        result1.Should().NotBeSameAs(result2);
        (result1 as SlackFileBlock)!.ExternalId.Should().Be((result2 as SlackFileBlock)!.ExternalId);
        (result1 as SlackFileBlock)!.Source.Should().Be((result2 as SlackFileBlock)!.Source);
    }
}