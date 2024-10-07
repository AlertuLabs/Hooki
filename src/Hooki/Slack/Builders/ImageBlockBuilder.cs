using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ImageBlockBuilder : IBlockBuilder
{
    private string? _altText;
    private string? _imageUrl;
    private SlackFileObject? _slackFile;
    private TextObject? _title;
    private string? _blockId;

    public ImageBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public ImageBlockBuilder WithAltText(string altText)
    {
        _altText = altText;
        return this;
    }

    public ImageBlockBuilder WithImageUrl(string imageUrl)
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

    public BlockBase Build()
    {
        if (_altText is null)
            throw new InvalidOperationException("AltText is required");

        if (_imageUrl is null && _slackFile is null)
            throw new InvalidOperationException("Either ImageUrl or SlackUrl need to be provided");
        
        return new ImageBlock
        {
            BlockId = _blockId,
            AltText = _altText,
            ImageUrl = _imageUrl,
            SlackFile = _slackFile,
            Title = _title,
        };
    }
}