using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.Inputs;

public class Choice
{
    [JsonPropertyName("display")] public string Display { get; set; } = default!;

    [JsonPropertyName("value")] public string Value { get; set; } = default!;
}