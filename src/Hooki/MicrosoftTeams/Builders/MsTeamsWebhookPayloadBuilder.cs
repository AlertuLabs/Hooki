using Hooki.MicrosoftTeams.Models;
using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsWebhookPayloadBuilder : MsTeamsActionBuilderBase<MsTeamsWebhookPayloadBuilder>
{
    private string? _correlationId;
    private List<string>? _expectedActors;
    private string? _originator;
    private string? _summary;
    private string? _themeColor;
    private bool? _hideOriginalBody;
    private string? _title;
    private string? _text;
    private List<MsTeamsSection>? _sections;
    
    private readonly List<MsTeamsAction> _potentialActions = [];
    protected override List<MsTeamsAction> PotentialActions => _potentialActions;

    public MsTeamsWebhookPayloadBuilder WithCorrelationId(string correlationId)
    {
        _correlationId = correlationId;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithOriginator(string originator)
    {
        _originator = originator;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithThemeColor(string color)
    {
        _themeColor = color;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithSummary(string summary)
    {
        _summary = summary;
        return this;
    }

    public MsTeamsWebhookPayloadBuilder AddSection(Action<MsTeamsSectionBuilder> sectionBuilder)
    {
        var section = new MsTeamsSectionBuilder();
        sectionBuilder(section);

        _sections ??= [];
        _sections.Add(section.Build());
        return this;
    }

    public MsTeamsWebhookPayloadBuilder AddExpectedActor(string expectedActor)
    {
        _expectedActors ??= [];
        _expectedActors.Add(expectedActor);
        return this;
    }

    public MsTeamsWebhookPayloadBuilder WithHiddenOriginalBody(bool hideOriginalBody)
    {
        _hideOriginalBody = hideOriginalBody;
        return this;
    }
    
    public MsTeamsWebhookPayload Build()
    {
        if (string.IsNullOrEmpty(_text) && string.IsNullOrEmpty(_summary))
        {
            throw new InvalidOperationException("Either Text or Summary must be provided.");
        }

        return new MsTeamsWebhookPayload
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