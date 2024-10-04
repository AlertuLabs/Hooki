using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.Actions;

public class InvokeAddInCommandAction : ActionBase
{
    public override ActionType Type => ActionType.InvokeAddInCommand;

    [JsonPropertyName("addInId")] public required string AddInId { get; set; }

    [JsonPropertyName("desktopCommandId")] public required string DesktopCommandId { get; set; }

    [JsonPropertyName("initializationContext")] public object? InitializationContext { get; set; }
}