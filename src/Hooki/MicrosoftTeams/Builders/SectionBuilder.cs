using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class SectionBuilder : ActionBuilderBase<SectionBuilder>
{
    private readonly Section _section = new();
    protected override List<ActionBase> PotentialActions => _section.PotentialActions ??= new List<ActionBase>();
    
    public Section Build() => _section;

    public SectionBuilder WithActivityTitle(string title)
    {
        _section.ActivityTitle = title;
        return this;
    }

    public SectionBuilder WithActivitySubtitle(string subtitle)
    {
        _section.ActivitySubtitle = subtitle;
        return this;
    }

    public SectionBuilder WithActivityText(string text)
    {
        _section.ActivityText = text;
        return this;
    }

    public SectionBuilder WithActivityImage(string imageUrl)
    {
        _section.ActivityImage = imageUrl;
        return this;
    }

    public SectionBuilder WithImages(List<Image> images)
    {
        _section.Images = images;
        return this;
    }
    
    public SectionBuilder AddImage(Image image)
    {
        _section.Images ??= [];
        _section.Images.Add(image);
        return this;
    }
    
    public SectionBuilder AddFact(string name, string value)
    {
        _section.Facts ??= [];
        _section.Facts.Add(new Fact { Name = name, Value = value });
        return this;
    }
}