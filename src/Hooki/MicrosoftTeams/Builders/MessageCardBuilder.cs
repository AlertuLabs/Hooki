using Hooki.MicrosoftTeams.Models;
using Hooki.MicrosoftTeams.Models.Actions;

namespace Hooki.MicrosoftTeams.Builders;

public class MessageCardBuilder : ActionBuilderBase<MessageCardBuilder>
{
    private readonly MessageCard _messageCard = new();
    protected override List<ActionBase> PotentialActions => _messageCard.PotentialActions ??= new List<ActionBase>();
    
    public MessageCard Build() => _messageCard;
    
    public MessageCardBuilder WithContext(string context)
    {
        _messageCard.Context = context;
        return this;
    }

    public MessageCardBuilder WithCorrelationId(string correlationId)
    {
        _messageCard.CorrelationId = correlationId;
        return this;
    }

    public MessageCardBuilder WithOriginator(string originator)
    {
        _messageCard.Originator = originator;
        return this;
    }

    public MessageCardBuilder WithTitle(string title)
    {
        _messageCard.Title = title;
        return this;
    }

    public MessageCardBuilder WithText(string text)
    {
        _messageCard.Text = text;
        return this;
    }

    public MessageCardBuilder WithThemeColor(string color)
    {
        _messageCard.ThemeColor = color;
        return this;
    }

    public MessageCardBuilder WithSummary(string summary)
    {
        _messageCard.Summary = summary;
        return this;
    }

    public MessageCardBuilder AddSection(Action<SectionBuilder> sectionBuilder)
    {
        var section = new SectionBuilder();
        sectionBuilder(section);

        _messageCard.Sections ??= [];
        _messageCard.Sections.Add(section.Build());
        return this;
    }

    public MessageCardBuilder AddExpectedActors(string expectedActor)
    {
        _messageCard.ExpectedActors.Add(expectedActor);
        return this;
    }

    public MessageCardBuilder HasHiddenOriginalBody(bool hasHiddenOriginalBody)
    {
        _messageCard.HideOriginalBody = hasHiddenOriginalBody;
        return this;
    }
}