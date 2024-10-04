using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.Inputs;

public class Choice
{
    [JsonPropertyName("display")] public required string Display { get; set; }

    [JsonPropertyName("value")] public required string Value { get; set; }
}