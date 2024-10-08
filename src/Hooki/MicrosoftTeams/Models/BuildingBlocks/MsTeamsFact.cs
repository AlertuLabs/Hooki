using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#openuri-action
/// </summary>
public class MsTeamsFact
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("value")] public required string Value { get; set; }
}