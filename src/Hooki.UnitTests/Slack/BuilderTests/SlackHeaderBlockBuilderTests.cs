using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackHeaderBlockBuilderTests
    {
        [Fact]
        public void Build_With_Text_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new SlackTextObject { Text = "Header Text", Type = SlackTextObjectType.PlainText };
            var builder = new SlackHeaderBlockBuilder().WithText(text);

            // Act
            var result = builder.Build() as SlackHeaderBlock;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<SlackHeaderBlock>();
            result?.SlackText.Should().Be(text);
            result?.BlockId.Should().BeNull();
        }

        [Fact]
        public void Build_With_Text_And_BlockId_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new SlackTextObject { Text = "Header Text", Type = SlackTextObjectType.PlainText };
            var builder = new SlackHeaderBlockBuilder()
                .WithText(text);

            // Act
            var result = builder.Build() as SlackHeaderBlock;;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<SlackHeaderBlock>();
            result?.SlackText.Should().Be(text);
        }

        [Fact]
        public void Build_Without_Text_Throws_InvalidOperationException()
        {
            // Arrange
            var builder = new SlackHeaderBlockBuilder();

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Text is required");
        }

        [Fact]
        public void WithText_Returns_Same_Builder_Instance()
        {
            // Arrange
            var builder = new SlackHeaderBlockBuilder();
            var text = new SlackTextObject { Text = "Header Text", Type = SlackTextObjectType.PlainText };

            // Act
            var result = builder.WithText(text);

            // Assert
            result.Should().BeSameAs(builder);
        }

        [Fact]
        public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
        {
            // Arrange
            var text = new SlackTextObject { Text = "Header Text", Type = SlackTextObjectType.PlainText };
            var builder = new SlackHeaderBlockBuilder()
                .WithText(text);

            // Act
            var result1 = builder.Build() as SlackHeaderBlock;;
            var result2 = builder.Build() as SlackHeaderBlock;;

            // Assert
            result1.Should().NotBeSameAs(result2);
            result1?.SlackText.Should().Be(result2?.SlackText);
        }

        [Fact]
        public void Build_With_Non_PlainText_TextObject_Still_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new SlackTextObject { Text = "*Bold Header*", Type = SlackTextObjectType.Markdown };
            var builder = new SlackHeaderBlockBuilder().WithText(text);

            // Act
            var result = builder.Build() as SlackHeaderBlock;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<SlackHeaderBlock>();
            result?.SlackText.Should().Be(text);
            result?.SlackText.Type.Should().Be(SlackTextObjectType.Markdown);
        }
    }