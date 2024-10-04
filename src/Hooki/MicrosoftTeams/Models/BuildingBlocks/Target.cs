using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Target
{
    [JsonPropertyName("os")] public required OperatingSystemType OperatingSystem { get; set; } = OperatingSystemType.Default;

    [JsonPropertyName("uri")] public required string Uri { get; set; }
}