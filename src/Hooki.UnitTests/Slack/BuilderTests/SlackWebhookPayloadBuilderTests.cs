using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;
using Hooki.Slack.Models.RichTextElements;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackWebhookPayloadBuilderTests
{
    [Fact]
    public void Build_With_Minimum_Required_Properties_Returns_Correct_SlackWebhookPayload()
    {
        // Arrange
        var builder = new SlackWebhookPayloadBuilder()
            .AddSectionBlock(b =>
                b.WithText(t => t.WithText("Test Text").WithType(TextObjectType.PlainText)));

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Blocks.Should().HaveCount(1);
        result.Blocks[0].Should().BeOfType<SectionBlock>();
        (result.Blocks[0] as SectionBlock)!.Text?.Text.Should().Be("Test Text");
    }

    [Fact]
public void Build_With_All_Possible_Blocks_Returns_Correct_SlackWebhookPayload()
{
    // Arrange
    var builder = new SlackWebhookPayloadBuilder()
        .AddSectionBlock(b =>
            b.WithText(t => t.WithText("Test Text").WithType(TextObjectType.PlainText))
                .AddField(t => t.WithText("Test Field").WithType(TextObjectType.PlainText)))
        .AddImageBlock(b =>
            b.WithImageUrl("http://example.com/image.jpg")
                .WithAltText("Image Text"))
        .AddActionBlock(a => 
            a.AddElement(() => new ButtonElement
                { Text = new TextObject { Text = "Button Text", Type = TextObjectType.PlainText } }))
        .AddContextBlock(c =>
        {
            c.AddElement(() => new ImageElement
                { AltText = "Image Text", ImageUrl = "http://example.com/image.jpg" });
            c.AddElement(() => new TextObject { Type = TextObjectType.PlainText, Text = "Text" });
        })
        .AddFileBlock(f => 
            f.WithExternalId("external-unique-id")
                .WithSource("source"))
        .AddHeaderBlock(h => 
            h.WithText(new TextObject { Type = TextObjectType.PlainText, Text = "Header Text" }))
        .AddInputBlock(i =>
            i.WithLabel(new TextObject { Type = TextObjectType.PlainText, Text = "Label" })
                .WithElement(() => new UrlInputElement
                {
                    Placeholder = new TextObject { Type = TextObjectType.PlainText, Text = "Text" },
                    InitialValue = "InitialValue"
                }))
        .AddRichTextBlock(r => 
            r.AddElement(() => new RichTextSection
                { Elements = new[] { new ChannelElement { ChannelId = "123" } } }))
        .AddVideoBlock(v =>
            v.WithAltText("Alt Text")
                .WithTitle(to => to.WithType(TextObjectType.PlainText).WithText("Text"))
                .WithThumbnailUrl("http://example.com/image.jpg")
                .WithVideoUrl("http://example.com/image.jpg")
                .WithDescription(to => to.WithType(TextObjectType.PlainText).WithText("Text")));


    // Act
    var result = builder.Build();

    // Assert
    result.Should().NotBeNull();
    result.Blocks.Should().HaveCount(9);
    result.Blocks[0].Should().BeOfType<SectionBlock>();
    result.Blocks[1].Should().BeOfType<ImageBlock>();
    result.Blocks[2].Should().BeOfType<ActionBlock>();
    result.Blocks[3].Should().BeOfType<ContextBlock>();
    result.Blocks[4].Should().BeOfType<FileBlock>();
    result.Blocks[5].Should().BeOfType<HeaderBlock>();
    result.Blocks[6].Should().BeOfType<InputBlock>();
    result.Blocks[7].Should().BeOfType<RichTextBlock>();
    result.Blocks[8].Should().BeOfType<VideoBlock>();
    
    // SectionBlock assertions
    var sectionBlock = result.Blocks[0] as SectionBlock;
    sectionBlock.Should().NotBeNull();
    sectionBlock!.Text?.Text.Should().Be("Test Text");
    sectionBlock.Text?.Type.Should().Be(TextObjectType.PlainText);
    sectionBlock.Fields.Should().HaveCount(1);
    sectionBlock.Fields![0].Text.Should().Be("Test Field");
    sectionBlock.Fields![0].Type.Should().Be(TextObjectType.PlainText);

    // ImageBlock assertions
    var imageBlock = result.Blocks[1] as ImageBlock;
    imageBlock.Should().NotBeNull();
    imageBlock!.ImageUrl.Should().Be("http://example.com/image.jpg");
    imageBlock.AltText.Should().Be("Image Text");

    // ActionBlock assertions
    var actionBlock = result.Blocks[2] as ActionBlock;
    actionBlock.Should().NotBeNull();
    actionBlock!.Elements.Should().HaveCount(1);
    var buttonElement = actionBlock.Elements[0] as ButtonElement;
    buttonElement.Should().NotBeNull();
    buttonElement!.Text.Text.Should().Be("Button Text");
    buttonElement.Text.Type.Should().Be(TextObjectType.PlainText);

    // ContextBlock assertions
    var contextBlock = result.Blocks[3] as ContextBlock;
    contextBlock.Should().NotBeNull();
    contextBlock!.Elements.Should().HaveCount(2);
    var imageElement = contextBlock.Elements[0] as ImageElement;
    imageElement.Should().NotBeNull();
    imageElement!.AltText.Should().Be("Image Text");
    imageElement.ImageUrl.Should().Be("http://example.com/image.jpg");
    var textElement = contextBlock.Elements[1] as TextObject;
    textElement.Should().NotBeNull();
    textElement!.Text.Should().Be("Text");
    textElement.Type.Should().Be(TextObjectType.PlainText);

    // FileBlock assertions
    var fileBlock = result.Blocks[4] as FileBlock;
    fileBlock.Should().NotBeNull();
    fileBlock!.ExternalId.Should().Be("external-unique-id");
    fileBlock.Source.Should().Be("source");

    // HeaderBlock assertions
    var headerBlock = result.Blocks[5] as HeaderBlock;
    headerBlock.Should().NotBeNull();
    headerBlock!.Text.Text.Should().Be("Header Text");
    headerBlock.Text.Type.Should().Be(TextObjectType.PlainText);

    // InputBlock assertions
    var inputBlock = result.Blocks[6] as InputBlock;
    inputBlock.Should().NotBeNull();
    inputBlock!.Label.Text.Should().Be("Label");
    inputBlock.Label.Type.Should().Be(TextObjectType.PlainText);
    var urlInputElement = inputBlock.Element as UrlInputElement;
    urlInputElement.Should().NotBeNull();
    urlInputElement!.Placeholder!.Text.Should().Be("Text");
    urlInputElement.Placeholder.Type.Should().Be(TextObjectType.PlainText);
    urlInputElement.InitialValue.Should().Be("InitialValue");

    // RichTextBlock assertions
    var richTextBlock = result.Blocks[7] as RichTextBlock;
    richTextBlock.Should().NotBeNull();
    richTextBlock!.Elements.Should().HaveCount(1);
    var richTextSection = richTextBlock.Elements[0] as RichTextSection;
    richTextSection.Should().NotBeNull();
    richTextSection!.Elements.Should().HaveCount(1);
    var channelElement = richTextSection.Elements[0] as ChannelElement;
    channelElement.Should().NotBeNull();
    channelElement!.ChannelId.Should().Be("123");

    // VideoBlock assertions
    var videoBlock = result.Blocks[8] as VideoBlock;
    videoBlock.Should().NotBeNull();
    videoBlock!.AltText.Should().Be("Alt Text");
    videoBlock.Title!.Text.Should().Be("Text");
    videoBlock.Title.Type.Should().Be(TextObjectType.PlainText);
    videoBlock.ThumbnailUrl.Should().Be("http://example.com/image.jpg");
    videoBlock.VideoUrl.Should().Be("http://example.com/image.jpg");
    videoBlock.Description!.Text.Should().Be("Text");
    videoBlock.Description.Type.Should().Be(TextObjectType.PlainText);
}

    [Fact]
    public void Build_With_No_Blocks_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackWebhookPayloadBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("At least one block is required.");
    }
}