using System.Text.Json.Serialization;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;

public class Target
{
    [JsonPropertyName("os")] public string OperatingSystem { get; set; } = default!;

    [JsonPropertyName("uri")] public string Uri { get; set; } = default!;
}