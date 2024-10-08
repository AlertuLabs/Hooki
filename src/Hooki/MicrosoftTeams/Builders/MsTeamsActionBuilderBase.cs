using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.Actions;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.Builders;

public abstract class MsTeamsActionBuilderBase<TBuilder> where TBuilder : MsTeamsActionBuilderBase<TBuilder>
{
    protected abstract List<MsTeamsAction> PotentialActions { get; }

    public TBuilder AddOpenUriAction(string name, string uri)
    {
        PotentialActions.Add(new MsTeamsOpenUriAction
        {
            Name = name,
            Targets = [new MsTeamsTarget { MsTeamsOperatingSystem = MsTeamsOperatingSystemType.Default, Uri = uri }]
        });
        return (TBuilder)this;
    }

    public TBuilder AddHttpPostAction(string name, string target, string body, string bodyContentType, List<MsTeamsHeader> headers)
    {
        PotentialActions.Add(new MsTeamsHttpPostAction
        {
            Name = name,
            Target = target,
            Body = body,
            BodyContentType = bodyContentType,
            Headers = headers
        });
        return (TBuilder)this;
    }

    public TBuilder AddActionCardAction(string name, List<MsTeamsInput>? inputs, List<MsTeamsAction> actions)
    {
        PotentialActions.Add(new MsTeamsActionCardAction
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
        PotentialActions.Add(new MsTeamsInvokeAddInCommandAction
        {
            Name = name,
            AddInId = addInId,
            DesktopCommandId = desktopCommandId,
            InitializationContext = initializationContext
        });
        return (TBuilder)this;
    }
}