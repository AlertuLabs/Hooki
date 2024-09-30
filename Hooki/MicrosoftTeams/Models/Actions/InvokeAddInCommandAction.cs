using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Actions;

public class InvokeAddInCommandAction : ActionBase
{
    public override ActionType Type => ActionType.InvokeAddInCommand;

    [JsonPropertyName("addInId")] public string AddInId { get; set; } = default!;

    [JsonPropertyName("desktopCommandId")] public string DesktopCommandId { get; set; } = default!;

    [JsonPropertyName("initializationContext")] public object? InitializationContext { get; set; }
}