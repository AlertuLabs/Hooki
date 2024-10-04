using Hooki.MicrosoftTeams.Models;
using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MessageCardBuilder : ActionBuilderBase<MessageCardBuilder>
{
    private string? _correlationId;
    private List<string>? _expectedActors;
    private string? _originator;
    private string? _summary;
    private string? _themeColor;
    private bool? _hideOriginalBody;
    private string? _title;
    private string? _text;
    private List<Section>? _sections;
    
    private readonly List<ActionBase> _potentialActions = [];
    protected override List<ActionBase> PotentialActions => _potentialActions;

    public MessageCardBuilder WithCorrelationId(string correlationId)
    {
        _correlationId = correlationId;
        return this;
    }

    public MessageCardBuilder WithOriginator(string originator)
    {
        _originator = originator;
        return this;
    }

    public MessageCardBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageCardBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public MessageCardBuilder WithThemeColor(string color)
    {
        _themeColor = color;
        return this;
    }

    public MessageCardBuilder WithSummary(string summary)
    {
        _summary = summary;
        return this;
    }

    public MessageCardBuilder AddSection(Action<SectionBuilder> sectionBuilder)
    {
        var section = new SectionBuilder();
        sectionBuilder(section);

        _sections ??= [];
        _sections.Add(section.Build());
        return this;
    }

    public MessageCardBuilder AddExpectedActor(string expectedActor)
    {
        _expectedActors ??= [];
        _expectedActors.Add(expectedActor);
        return this;
    }

    public MessageCardBuilder WithHiddenOriginalBody(bool hideOriginalBody)
    {
        _hideOriginalBody = hideOriginalBody;
        return this;
    }
    
    public MessageCard Build()
    {
        if (string.IsNullOrEmpty(_text) && string.IsNullOrEmpty(_summary))
        {
            throw new InvalidOperationException("Either Text or Summary must be provided.");
        }

        return new MessageCard
        {
            CorrelationId = _correlationId,
            ExpectedActors = _expectedActors,
            Originator = _originator,
            Summary = _summary,
            ThemeColor = _themeColor,
            HideOriginalBody = _hideOriginalBody,
            Title = _title,
            Text = _text,
            Sections = _sections,
            PotentialActions = _potentialActions.Count > 0 ? _potentialActions : null
        };
    }
}