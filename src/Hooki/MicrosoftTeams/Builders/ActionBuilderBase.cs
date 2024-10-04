using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.Builders;

public abstract class ActionBuilderBase<TBuilder> where TBuilder : ActionBuilderBase<TBuilder>
{
    protected abstract List<ActionBase> PotentialActions { get; }

    public TBuilder AddOpenUriAction(string name, string uri)
    {
        PotentialActions.Add(new OpenUriAction
        {
            Name = name,
            Targets = [new Target { OperatingSystem = OperatingSystemTypes.Default, Uri = uri }]
        });
        return (TBuilder)this;
    }

    public TBuilder AddHttpPostAction(string name, string target, string body, string bodyContentType, List<Header> headers)
    {
        PotentialActions.Add(new HttpPostAction
        {
            Name = name,
            Target = target,
            Body = body,
            BodyContentType = bodyContentType,
            Headers = headers
        });
        return (TBuilder)this;
    }

    public TBuilder AddActionCardAction(string name, List<InputBase>? inputs, List<ActionBase> actions)
    {
        PotentialActions.Add(new ActionCardAction
        {
            Name = name,
            Inputs = inputs,
            Actions = actions
        });
        return (TBuilder)this;
    }

    public TBuilder AddInvokeAddInCommandAction(
        string name, 
        string addInId, 
        string desktopCommandId,
        object? initializationContext)
    {
        PotentialActions.Add(new InvokeAddInCommandAction
        {
            Name = name,
            AddInId = addInId,
            DesktopCommandId = desktopCommandId,
            InitializationContext = initializationContext
        });
        return (TBuilder)this;
    }
}