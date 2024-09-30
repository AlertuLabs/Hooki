using System.Text.Json.Serialization;
using Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Inputs;
using Hooki.MicrosoftTeams.Enums;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Actions;

public class ActionCardAction : ActionBase
{
    public override ActionType Type => ActionType.ActionCard;

    [JsonPropertyName("inputs")] public List<InputBase> Inputs { get; set; } = [];

    [JsonPropertyName("actions")] public List<ActionBase> Actions { get; set; } = [];
}