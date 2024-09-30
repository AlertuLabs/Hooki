using System.Text.Json.Serialization;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;

public class Header
{
    [JsonPropertyName("name")] public string Name { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;
}