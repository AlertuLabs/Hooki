using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Actions;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#invokeaddincommand-action
/// </summary>
public class InvokeAddInCommandAction : ActionBase
{
    public override ActionType Type => ActionType.InvokeAddInCommand;

    [JsonPropertyName("addInId")] public required string AddInId { get; set; }

    [JsonPropertyName("desktopCommandId")] public required string DesktopCommandId { get; set; }

    [JsonPropertyName("initializationContext")] public object? InitializationContext { get; set; }
}