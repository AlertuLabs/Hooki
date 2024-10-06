using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class ImageBlockBuilder
{
    private string? _imageUrl;
    private string? _title;

    public ImageBlockBuilder WithImageUrl(string imageUrl)
    {
        _imageUrl = imageUrl;
        return this;
    }

    public ImageBlockBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public Image Build()
    {
        return new Image
        {
            ImageUrl = _imageUrl ?? throw new InvalidOperationException("ImageUrl is required"),
            Title = _title
        };
    }
}