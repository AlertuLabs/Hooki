using System.Text.Json.Serialization;
using Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;
using Hooki.MicrosoftTeams.Enums;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Actions;

public class OpenUriAction : ActionBase
{
    public override ActionType Type => ActionType.OpenUri;

    [JsonPropertyName("targets")] public List<Target> Targets { get; set; } = [];
}