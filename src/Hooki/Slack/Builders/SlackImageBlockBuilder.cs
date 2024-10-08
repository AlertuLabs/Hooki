using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackImageBlockBuilder : ISlackBlockBuilder
{
    private string? _altText;
    private string? _imageUrl;
    private SlackFileObject? _slackFile;
    private SlackTextObject? _title;
    private string? _blockId;

    public SlackImageBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public SlackImageBlockBuilder WithAltText(string altText)
    {
        _altText = altText;
        return this;
    }

    public SlackImageBlockBuilder WithImageUrl(string imageUrl)
    {
        _imageUrl = imageUrl;
        return this;
    }

    public SlackImageBlockBuilder WithSlackFile(SlackFileObject slackFile)
    {
        _slackFile = slackFile;
        return this;
    }

    public SlackImageBlockBuilder WithTitle(SlackTextObject title)
    {
        _title = title;
        return this;
    }

    public SlackBlock Build()
    {
        if (_altText is null)
            throw new InvalidOperationException("AltText is required");

        if (_imageUrl is null && _slackFile is null)
            throw new InvalidOperationException("Either ImageUrl or SlackUrl need to be provided");
        
        return new SlackImageBlock
        {
            BlockId = _blockId,
            AltText = _altText,
            ImageUrl = _imageUrl,
            SlackFile = _slackFile,
            Title = _title,
        };
    }
}