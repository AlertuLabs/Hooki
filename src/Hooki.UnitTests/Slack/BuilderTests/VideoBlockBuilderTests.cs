using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class VideoBlockBuilderTests
    {
        [Fact]
        public void Build_WithAllRequiredProperties_ReturnsValidVideoBlock()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act
            var result = builder.Build() as VideoBlock;

            // Assert
            result.Should().NotBeNull();
            result!.AltText.Should().Be("Alt Text");
            result.Description.Should().NotBeNull();
            result.Description!.Text.Should().Be("Description");
            result.Description.Type.Should().Be(TextObjectType.PlainText);
            result.ThumbnailUrl.Should().Be("https://example.com/thumbnail.jpg");
            result.VideoUrl.Should().Be("https://example.com/video.mp4");
        }

        [Fact]
        public void Build_WithAllProperties_ReturnsValidVideoBlock()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithAuthorName("Author")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithProviderIconUrl("https://example.com/icon.png")
                .WithProviderName("Provider")
                .WithTitle(t => t.WithText("Title").WithType(TextObjectType.PlainText))
                .WithTitleUrl("https://example.com/title")
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act
            var result = builder.Build() as VideoBlock;

            // Assert
            result.Should().NotBeNull();
            result?.AltText.Should().Be("Alt Text");
            result?.AuthorName.Should().Be("Author");
            result?.Description.Should().NotBeNull();
            result?.Description!.Text.Should().Be("Description");
            result?.ProviderIconUrl.Should().Be("https://example.com/icon.png");
            result?.ProviderName.Should().Be("Provider");
            result?.Title.Should().NotBeNull();
            result?.Title?.Text.Should().Be("Title");
            result?.TitleUrl.Should().Be("https://example.com/title");
            result?.ThumbnailUrl.Should().Be("https://example.com/thumbnail.jpg");
            result?.VideoUrl.Should().Be("https://example.com/video.mp4");
        }

        [Fact]
        public void Build_WithoutAltText_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("AltText is required for a VideoBlock.");
        }

        [Fact]
        public void Build_WithoutDescription_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Description is required for a VideoBlock.");
        }

        [Fact]
        public void Build_WithMarkdownDescription_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.Markdown))
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Description must be of type PlainText.");
        }

        [Fact]
        public void Build_WithMarkdownTitle_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithTitle(t => t.WithText("Title").WithType(TextObjectType.Markdown))
                .WithThumbnailUrl("https://example.com/thumbnail.jpg")
                .WithVideoUrl("https://example.com/video.mp4");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Title must be of type PlainText.");
        }

        [Fact]
        public void Build_WithoutThumbnailUrl_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithVideoUrl("https://example.com/video.mp4");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("ThumbnailUrl is required for a VideoBlock.");
        }

        [Fact]
        public void Build_WithoutVideoUrl_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new VideoBlockBuilder()
                .WithAltText("Alt Text")
                .WithDescription(d => d.WithText("Description").WithType(TextObjectType.PlainText))
                .WithThumbnailUrl("https://example.com/thumbnail.jpg");

            // Act & Assert
            builder.Invoking(b => b.Build())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("VideoUrl is required for a VideoBlock.");
        }

        [Fact]
        public void WithTitleUrl_WithNonHttpsUrl_ThrowsArgumentException()
        {
            // Arrange
            var builder = new VideoBlockBuilder();

            // Act & Assert
            builder.Invoking(b => b.WithTitleUrl("http://example.com"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Title URL must start with 'https://'*");
        }
    }