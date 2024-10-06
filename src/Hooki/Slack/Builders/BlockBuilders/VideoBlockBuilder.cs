using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Builders;

public class VideoBlockBuilder : BlockBaseBuilder
{
    private string? _altText;
    private string? _authorName;
    private TextObject? _description;
    private string? _providerIconUrl;
    private string? _providerName;
    private TextObject? _title;
    private string? _titleUrl;
    private string? _thumbnailUrl;
    private string? _videoUrl;

    public VideoBlockBuilder WithAltText(string altText)
    {
        _altText = altText;
        return this;
    }

    public VideoBlockBuilder WithAuthorName(string authorName)
    {
        _authorName = authorName;
        return this;
    }

    public VideoBlockBuilder WithDescription(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _description = builder.Build();
        return this;
    }

    public VideoBlockBuilder WithProviderIconUrl(string providerIconUrl)
    {
        _providerIconUrl = providerIconUrl;
        return this;
    }

    public VideoBlockBuilder WithProviderName(string providerName)
    {
        _providerName = providerName;
        return this;
    }

    public VideoBlockBuilder WithTitle(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _title = builder.Build();
        return this;
    }

    public VideoBlockBuilder WithTitleUrl(string titleUrl)
    {
        if (!titleUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Title URL must start with 'https://'", nameof(titleUrl));

        _titleUrl = titleUrl;
        return this;
    }

    public VideoBlockBuilder WithThumbnailUrl(string thumbnailUrl)
    {
        _thumbnailUrl = thumbnailUrl;
        return this;
    }

    public VideoBlockBuilder WithVideoUrl(string videoUrl)
    {
        _videoUrl = videoUrl;
        return this;
    }

    public override BlockBase Build()
    {
        if (string.IsNullOrWhiteSpace(_altText))
            throw new InvalidOperationException("AltText is required for a VideoBlock.");

        if (_description == null)
            throw new InvalidOperationException("Description is required for a VideoBlock.");

        if (_description.Type != TextObjectType.PlainText)
            throw new InvalidOperationException("Description must be of type PlainText.");

        if (_title != null && _title.Type != TextObjectType.PlainText)
            throw new InvalidOperationException("Title must be of type PlainText.");

        if (string.IsNullOrWhiteSpace(_thumbnailUrl))
            throw new InvalidOperationException("ThumbnailUrl is required for a VideoBlock.");

        if (string.IsNullOrWhiteSpace(_videoUrl))
            throw new InvalidOperationException("VideoUrl is required for a VideoBlock.");

        return new VideoBlock
        {
            BlockId = base.Build().BlockId,
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