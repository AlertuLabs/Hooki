using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.JsonConverters;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.Models.Actions;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#actioncard-action
/// </summary>
public class ActionCardAction : ActionBase
{
    public override ActionType Type => ActionType.ActionCard;
    
    [JsonPropertyName("inputs")] public List<InputBase>? Inputs { get; set; }

    /// <summary>
    /// Actions be of type OpenUri or HttpPOST.
    /// The actions property of an ActionCard action cannot contain another ActionCard action.
    /// </summary>
    [JsonPropertyName("actions")] public required List<ActionBase>? Actions { get; set; }
}