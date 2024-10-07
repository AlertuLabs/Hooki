using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ImageBlockElementBuilder: BlockElementBaseBuilder
{
    private string? _altText;
    private string? _imageUrl;
    private SlackFileObject? _slackFile;

    public ImageBlockElementBuilder WithAltText(string altText)
    {
        _altText = altText;
        return this;
    }

    public ImageBlockElementBuilder WithImageUrl(string imageUrl)
    {
        if (imageUrl.Length > 3000)
            throw new ArgumentException("ImageUrl must not exceed 3000 characters.", nameof(imageUrl));

        _imageUrl = imageUrl;
        return this;
    }

    public ImageBlockElementBuilder WithSlackFile(SlackFileObject slackFile)
    {
        _slackFile = slackFile;
        return this;
    }

    public override BlockElementBase Build()
    {
        if (string.IsNullOrWhiteSpace(_altText))
            throw new InvalidOperationException("AltText is required for an ImageElement.");

        if (_imageUrl == null && _slackFile == null)
            throw new InvalidOperationException("Either ImageUrl or SlackFile must be provided for an ImageElement.");

        if (_imageUrl != null && _slackFile != null)
            throw new InvalidOperationException("Only one of ImageUrl or SlackFile can be provided for an ImageElement.");

        return new ImageElement
        {
            ActionId = base.Build().ActionId,
            AltText = _altText,
            ImageUrl = _imageUrl,
            SlackFile = _slackFile
        };
    }
}
