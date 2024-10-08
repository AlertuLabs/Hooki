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
                b.WithText(t => t.WithText("Test Text").WithType(SlackTextObjectType.PlainText)));

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Blocks.Should().HaveCount(1);
        result.Blocks[0].Should().BeOfType<SlackSectionBlock>();
        (result.Blocks[0] as SlackSectionBlock)!.Text?.Text.Should().Be("Test Text");
    }

    [Fact]
public void Build_With_All_Possible_Blocks_Returns_Correct_SlackWebhookPayload()
{
    // Arrange
    var builder = new SlackWebhookPayloadBuilder()
        .AddSectionBlock(b =>
            b.WithText(t => t.WithText("Test Text").WithType(SlackTextObjectType.PlainText))
                .AddField(t => t.WithText("Test Field").WithType(SlackTextObjectType.PlainText)))
        .AddImageBlock(b =>
            b.WithImageUrl("http://example.com/image.jpg")
                .WithAltText("Image Text"))
        .AddActionBlock(a => 
            a.AddElement(() => new SlackButtonElement
                { SlackText = new SlackTextObject { Text = "Button Text", Type = SlackTextObjectType.PlainText } }))
        .AddContextBlock(c =>
        {
            c.AddElement(() => new SlackImageElement
                { AltText = "Image Text", ImageUrl = "http://example.com/image.jpg" });
            c.AddElement(() => new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Text" });
        })
        .AddFileBlock(f => 
            f.WithExternalId("external-unique-id")
                .WithSource("source"))
        .AddHeaderBlock(h => 
            h.WithText(new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Header Text" }))
        .AddInputBlock(i =>
            i.WithLabel(new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Label" })
                .WithElement(() => new SlackUrlInputElement
                {
                    Placeholder = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Text" },
                    InitialValue = "InitialValue"
                }))
        .AddRichTextBlock(r => 
            r.AddElement(() => new SlackRichTextSection
                { Elements = new[] { new SlackChannelElement { ChannelId = "123" } } }))
        .AddVideoBlock(v =>
            v.WithAltText("Alt Text")
                .WithTitle(to => to.WithType(SlackTextObjectType.PlainText).WithText("Text"))
                .WithThumbnailUrl("http://example.com/image.jpg")
                .WithVideoUrl("http://example.com/image.jpg")
                .WithDescription(to => to.WithType(SlackTextObjectType.PlainText).WithText("Text")));


    // Act
    var result = builder.Build();

    // Assert
    result.Should().NotBeNull();
    result.Blocks.Should().HaveCount(9);
    result.Blocks[0].Should().BeOfType<SlackSectionBlock>();
    result.Blocks[1].Should().BeOfType<SlackImageBlock>();
    result.Blocks[2].Should().BeOfType<SlackActionBlock>();
    result.Blocks[3].Should().BeOfType<SlackContextBlock>();
    result.Blocks[4].Should().BeOfType<SlackFileBlock>();
    result.Blocks[5].Should().BeOfType<SlackHeaderBlock>();
    result.Blocks[6].Should().BeOfType<SlackInputBlock>();
    result.Blocks[7].Should().BeOfType<SlackRichTextBlock>();
    result.Blocks[8].Should().BeOfType<SlackVideoBlock>();
    
    // SectionBlock assertions
    var sectionBlock = result.Blocks[0] as SlackSectionBlock;
    sectionBlock.Should().NotBeNull();
    sectionBlock!.Text?.Text.Should().Be("Test Text");
    sectionBlock.Text?.Type.Should().Be(SlackTextObjectType.PlainText);
    sectionBlock.Fields.Should().HaveCount(1);
    sectionBlock.Fields![0].Text.Should().Be("Test Field");
    sectionBlock.Fields![0].Type.Should().Be(SlackTextObjectType.PlainText);

    // ImageBlock assertions
    var imageBlock = result.Blocks[1] as SlackImageBlock;
    imageBlock.Should().NotBeNull();
    imageBlock!.ImageUrl.Should().Be("http://example.com/image.jpg");
    imageBlock.AltText.Should().Be("Image Text");

    // ActionBlock assertions
    var actionBlock = result.Blocks[2] as SlackActionBlock;
    actionBlock.Should().NotBeNull();
    actionBlock!.Elements.Should().HaveCount(1);
    var buttonElement = actionBlock.Elements[0] as SlackButtonElement;
    buttonElement.Should().NotBeNull();
    buttonElement!.SlackText.Text.Should().Be("Button Text");
    buttonElement.SlackText.Type.Should().Be(SlackTextObjectType.PlainText);

    // ContextBlock assertions
    var contextBlock = result.Blocks[3] as SlackContextBlock;
    contextBlock.Should().NotBeNull();
    contextBlock!.Elements.Should().HaveCount(2);
    var imageElement = contextBlock.Elements[0] as SlackImageElement;
    imageElement.Should().NotBeNull();
    imageElement!.AltText.Should().Be("Image Text");
    imageElement.ImageUrl.Should().Be("http://example.com/image.jpg");
    var textElement = contextBlock.Elements[1] as SlackTextObject;
    textElement.Should().NotBeNull();
    textElement!.Text.Should().Be("Text");
    textElement.Type.Should().Be(SlackTextObjectType.PlainText);

    // FileBlock assertions
    var fileBlock = result.Blocks[4] as SlackFileBlock;
    fileBlock.Should().NotBeNull();
    fileBlock!.ExternalId.Should().Be("external-unique-id");
    fileBlock.Source.Should().Be("source");

    // HeaderBlock assertions
    var headerBlock = result.Blocks[5] as SlackHeaderBlock;
    headerBlock.Should().NotBeNull();
    headerBlock!.SlackText.Text.Should().Be("Header Text");
    headerBlock.SlackText.Type.Should().Be(SlackTextObjectType.PlainText);

    // InputBlock assertions
    var inputBlock = result.Blocks[6] as SlackInputBlock;
    inputBlock.Should().NotBeNull();
    inputBlock!.Label.Text.Should().Be("Label");
    inputBlock.Label.Type.Should().Be(SlackTextObjectType.PlainText);
    var urlInputElement = inputBlock.Element as SlackUrlInputElement;
    urlInputElement.Should().NotBeNull();
    urlInputElement!.Placeholder!.Text.Should().Be("Text");
    urlInputElement.Placeholder.Type.Should().Be(SlackTextObjectType.PlainText);
    urlInputElement.InitialValue.Should().Be("InitialValue");

    // RichTextBlock assertions
    var richTextBlock = result.Blocks[7] as SlackRichTextBlock;
    richTextBlock.Should().NotBeNull();
    richTextBlock!.Elements.Should().HaveCount(1);
    var richTextSection = richTextBlock.Elements[0] as SlackRichTextSection;
    richTextSection.Should().NotBeNull();
    richTextSection!.Elements.Should().HaveCount(1);
    var channelElement = richTextSection.Elements[0] as SlackChannelElement;
    channelElement.Should().NotBeNull();
    channelElement!.ChannelId.Should().Be("123");

    // VideoBlock assertions
    var videoBlock = result.Blocks[8] as SlackVideoBlock;
    videoBlock.Should().NotBeNull();
    videoBlock!.AltText.Should().Be("Alt Text");
    videoBlock.Title!.Text.Should().Be("Text");
    videoBlock.Title.Type.Should().Be(SlackTextObjectType.PlainText);
    videoBlock.ThumbnailUrl.Should().Be("http://example.com/image.jpg");
    videoBlock.VideoUrl.Should().Be("http://example.com/image.jpg");
    videoBlock.Description!.Text.Should().Be("Text");
    videoBlock.Description.Type.Should().Be(SlackTextObjectType.PlainText);
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