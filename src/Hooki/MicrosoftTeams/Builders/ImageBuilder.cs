using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class ImageBuilder
{
    private string? _imageUrl;
    private string? _title;

    public ImageBuilder WithImageUrl(string imageUrl)
    {
        _imageUrl = imageUrl;
        return this;
    }

    public ImageBuilder WithTitle(string title)
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