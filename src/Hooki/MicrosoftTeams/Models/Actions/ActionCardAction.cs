using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.Models.Actions;

public class ActionCardAction : ActionBase
{
    public override ActionType Type => ActionType.ActionCard;

    [JsonPropertyName("inputs")] public List<InputBase> Inputs { get; set; } = [];

    [JsonPropertyName("actions")] public List<ActionBase> Actions { get; set; } = [];
}