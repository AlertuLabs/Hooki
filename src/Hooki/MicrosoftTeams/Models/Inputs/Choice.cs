using System.Text.Json.Serialization;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.Inputs;

public class Choice
{
    [JsonPropertyName("display")] public string Display { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;
}