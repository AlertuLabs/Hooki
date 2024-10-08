using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsImageBlockBuilder
{
    private string? _imageUrl;
    private string? _title;

    public MsTeamsImageBlockBuilder WithImageUrl(string imageUrl)
    {
        _imageUrl = imageUrl;
        return this;
    }

    public MsTeamsImageBlockBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MsTeamsImage Build()
    {
        return new MsTeamsImage
        {
            ImageUrl = _imageUrl ?? throw new InvalidOperationException("ImageUrl is required"),
            Title = _title
        };
    }
}