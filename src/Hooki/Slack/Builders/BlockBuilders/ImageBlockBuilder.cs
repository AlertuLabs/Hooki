using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ImageBlockBuilder
{
    private TextObject? _altText;
    private string? _imageUrl;
    private SlackFileObject? _slackFile;
    private TextObject? _title;
    private string? _blockId;

    public ImageBlockBuilder WithAltText(TextObject altText)
    {
        _altText = altText;
        return this;
    }

    public ImageBlockBuilder WithImageUrk(string imageUrl)
    {
        _imageUrl = imageUrl;
        return this;
    }

    public ImageBlockBuilder WithSlackFile(SlackFileObject slackFile)
    {
        _slackFile = slackFile;
        return this;
    }

    public ImageBlockBuilder WithTitle(TextObject title)
    {
        _title = title;
        return this;
    }

    public ImageBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public ImageBlock Build()
    {
        return new ImageBlock
        {
            AltText = _altText,
            ImageUrl = _imageUrl,
            SlackFile = _slackFile,
            Title = _title,
            BlockId = _blockId
        };
    }
}