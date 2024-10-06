using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class SectionBuilder : ActionBuilderBase<SectionBuilder>
{
    private string? _title;
    private bool? _startGroup;
    private string? _activityImage;
    private string? _activityTitle;
    private string? _activitySubtitle;
    private string? _activityText;
    private Image? _heroImage;
    private string? _text;
    private List<Fact>? _facts;
    private List<Image>? _images;
    
    private readonly List<ActionBase> _potentialActions = [];
    protected override List<ActionBase> PotentialActions => _potentialActions;

    public SectionBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public SectionBuilder WithStartGroup(bool startGroup)
    {
        _startGroup = startGroup;
        return this;
    }

    public SectionBuilder WithActivityImage(string imageUrl)
    {
        _activityImage = imageUrl;
        return this;
    }

    public SectionBuilder WithActivityTitle(string title)
    {
        _activityTitle = title;
        return this;
    }

    public SectionBuilder WithActivitySubtitle(string subtitle)
    {
        _activitySubtitle = subtitle;
        return this;
    }

    public SectionBuilder WithActivityText(string text)
    {
        _activityText = text;
        return this;
    }
    
    public SectionBuilder WithHeroImage(Action<ImageBlockBuilder> imageBuilderAction)
    {
        var imageBuilder = new ImageBlockBuilder();
        imageBuilderAction(imageBuilder);
        _heroImage = imageBuilder.Build();
        return this;
    }

    public SectionBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public SectionBuilder AddImage(Action<ImageBlockBuilder> imageBuilderAction)
    {
        var imageBuilder = new ImageBlockBuilder();
        imageBuilderAction(imageBuilder);
        _images ??= new List<Image>();
        _images.Add(imageBuilder.Build());
        return this;
    }

    public SectionBuilder AddFact(Action<FactBuilder> factBuilderAction)
    {
        var factBuilder = new FactBuilder();
        factBuilderAction(factBuilder);
        _facts ??= new List<Fact>();
        _facts.Add(factBuilder.Build());
        return this;
    }


    public Section Build()
    {
        return new Section
        {
            Title = _title,
            StartGroup = _startGroup,
            ActivityImage = _activityImage,
            ActivityTitle = _activityTitle,
            ActivitySubtitle = _activitySubtitle,
            ActivityText = _activityText,
            HeroImage = _heroImage,
            Text = _text,
            Facts = _facts,
            Images = _images,
            PotentialActions = _potentialActions.Count > 0 ? _potentialActions : null
        };
    }
}
