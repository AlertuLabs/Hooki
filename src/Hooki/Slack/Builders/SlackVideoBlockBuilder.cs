using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Builders;

public class SlackVideoBlockBuilder : ISlackBlockBuilder
{
    private string? _altText;
    private string? _authorName;
    private SlackTextObject? _description;
    private string? _providerIconUrl;
    private string? _providerName;
    private SlackTextObject? _title;
    private string? _titleUrl;
    private string? _thumbnailUrl;
    private string? _videoUrl;
    private string? _blockId;

    public SlackVideoBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackVideoBlockBuilder WithAltText(string altText)
    {
        _altText = altText;
        return this;
    }

    public SlackVideoBlockBuilder WithAuthorName(string authorName)
    {
        _authorName = authorName;
        return this;
    }

    public SlackVideoBlockBuilder WithDescription(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _description = builder.Build();
        return this;
    }

    public SlackVideoBlockBuilder WithProviderIconUrl(string providerIconUrl)
    {
        _providerIconUrl = providerIconUrl;
        return this;
    }

    public SlackVideoBlockBuilder WithProviderName(string providerName)
    {
        _providerName = providerName;
        return this;
    }

    public SlackVideoBlockBuilder WithTitle(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _title = builder.Build();
        return this;
    }

    public SlackVideoBlockBuilder WithTitleUrl(string titleUrl)
    {
        if (!titleUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Title URL must start with 'https://'", nameof(titleUrl));

        _titleUrl = titleUrl;
        return this;
    }

    public SlackVideoBlockBuilder WithThumbnailUrl(string thumbnailUrl)
    {
        _thumbnailUrl = thumbnailUrl;
        return this;
    }

    public SlackVideoBlockBuilder WithVideoUrl(string videoUrl)
    {
        _videoUrl = videoUrl;
        return this;
    }

    public SlackBlock Build()
    {
        if (string.IsNullOrWhiteSpace(_altText))
            throw new InvalidOperationException("AltText is required for a VideoBlock.");

        if (_description == null)
            throw new InvalidOperationException("Description is required for a VideoBlock.");

        if (_description.Type != SlackTextObjectType.PlainText)
            throw new InvalidOperationException("Description must be of type PlainText.");

        if (_title != null && _title.Type != SlackTextObjectType.PlainText)
            throw new InvalidOperationException("Title must be of type PlainText.");

        if (string.IsNullOrWhiteSpace(_thumbnailUrl))
            throw new InvalidOperationException("ThumbnailUrl is required for a VideoBlock.");

        if (string.IsNullOrWhiteSpace(_videoUrl))
            throw new InvalidOperationException("VideoUrl is required for a VideoBlock.");

        return new SlackVideoBlock
        {
            BlockId = _blockId,
            AltText = _altText,
            AuthorName = _authorName,
            Description = _description,
            ProviderIconUrl = _providerIconUrl,
            ProviderName = _providerName,
            Title = _title,
            TitleUrl = _titleUrl,
            ThumbnailUrl = _thumbnailUrl,
            VideoUrl = _videoUrl
        };
    }
}