using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.Inputs;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#multichoiceinput
/// </summary>
public class MsTeamsChoice
{
    [JsonPropertyName("display")] public required string Display { get; set; }

    [JsonPropertyName("value")] public required string Value { get; set; }
}