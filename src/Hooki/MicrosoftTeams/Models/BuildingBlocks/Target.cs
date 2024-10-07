using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#openuri-action
/// </summary>
public class Target
{
    [JsonPropertyName("os")] public required OperatingSystemType OperatingSystem { get; set; } = OperatingSystemType.Default;

    [JsonPropertyName("uri")] public required string Uri { get; set; }
}