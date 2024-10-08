using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsSectionBuilder : MsTeamsActionBuilderBase<MsTeamsSectionBuilder>
{
    private string? _title;
    private bool? _startGroup;
    private string? _activityImage;
    private string? _activityTitle;
    private string? _activitySubtitle;
    private string? _activityText;
    private MsTeamsImage? _heroImage;
    private string? _text;
    private List<MsTeamsFact>? _facts;
    private List<MsTeamsImage>? _images;
    
    private readonly List<MsTeamsAction> _potentialActions = [];
    protected override List<MsTeamsAction> PotentialActions => _potentialActions;

    public MsTeamsSectionBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MsTeamsSectionBuilder WithStartGroup(bool startGroup)
    {
        _startGroup = startGroup;
        return this;
    }

    public MsTeamsSectionBuilder WithActivityImage(string imageUrl)
    {
        _activityImage = imageUrl;
        return this;
    }

    public MsTeamsSectionBuilder WithActivityTitle(string title)
    {
        _activityTitle = title;
        return this;
    }

    public MsTeamsSectionBuilder WithActivitySubtitle(string subtitle)
    {
        _activitySubtitle = subtitle;
        return this;
    }

    public MsTeamsSectionBuilder WithActivityText(string text)
    {
        _activityText = text;
        return this;
    }
    
    public MsTeamsSectionBuilder WithHeroImage(Action<MsTeamsImageBlockBuilder> imageBuilderAction)
    {
        var imageBuilder = new MsTeamsImageBlockBuilder();
        imageBuilderAction(imageBuilder);
        _heroImage = imageBuilder.Build();
        return this;
    }

    public MsTeamsSectionBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public MsTeamsSectionBuilder AddImage(Action<MsTeamsImageBlockBuilder> imageBuilderAction)
    {
        var imageBuilder = new MsTeamsImageBlockBuilder();
        imageBuilderAction(imageBuilder);
        _images ??= new List<MsTeamsImage>();
        _images.Add(imageBuilder.Build());
        return this;
    }

    public MsTeamsSectionBuilder AddFact(Action<MsTeamsFactBuilder> factBuilderAction)
    {
        var factBuilder = new MsTeamsFactBuilder();
        factBuilderAction(factBuilder);
        _facts ??= new List<MsTeamsFact>();
        _facts.Add(factBuilder.Build());
        return this;
    }


    public MsTeamsSection Build()
    {
        return new MsTeamsSection
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
