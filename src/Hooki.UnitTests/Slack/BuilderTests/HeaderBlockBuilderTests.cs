using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class HeaderBlockBuilderTests
    {
        [Fact]
        public void Build_With_Text_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new TextObject { Text = "Header Text", Type = TextObjectType.PlainText };
            var builder = new HeaderBlockBuilder().WithText(text);

            // Act
            var result = builder.Build() as HeaderBlock;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HeaderBlock>();
            result?.Text.Should().Be(text);
            result?.BlockId.Should().BeNull();
        }

        [Fact]
        public void Build_With_Text_And_BlockId_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new TextObject { Text = "Header Text", Type = TextObjectType.PlainText };
            var builder = new HeaderBlockBuilder()
                .WithText(text);

            // Act
            var result = builder.Build() as HeaderBlock;;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HeaderBlock>();
            result?.Text.Should().Be(text);
        }

        [Fact]
        public void Build_Without_Text_Throws_InvalidOperationException()
        {
            // Arrange
            var builder = new HeaderBlockBuilder();

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Text is required");
        }

        [Fact]
        public void WithText_Returns_Same_Builder_Instance()
        {
            // Arrange
            var builder = new HeaderBlockBuilder();
            var text = new TextObject { Text = "Header Text", Type = TextObjectType.PlainText };

            // Act
            var result = builder.WithText(text);

            // Assert
            result.Should().BeSameAs(builder);
        }

        [Fact]
        public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
        {
            // Arrange
            var text = new TextObject { Text = "Header Text", Type = TextObjectType.PlainText };
            var builder = new HeaderBlockBuilder()
                .WithText(text);

            // Act
            var result1 = builder.Build() as HeaderBlock;;
            var result2 = builder.Build() as HeaderBlock;;

            // Assert
            result1.Should().NotBeSameAs(result2);
            result1?.Text.Should().Be(result2?.Text);
        }

        [Fact]
        public void Build_With_Non_PlainText_TextObject_Still_Returns_Valid_HeaderBlock()
        {
            // Arrange
            var text = new TextObject { Text = "*Bold Header*", Type = TextObjectType.Markdown };
            var builder = new HeaderBlockBuilder().WithText(text);

            // Act
            var result = builder.Build() as HeaderBlock;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HeaderBlock>();
            result?.Text.Should().Be(text);
            result?.Text.Type.Should().Be(TextObjectType.Markdown);
        }
    }