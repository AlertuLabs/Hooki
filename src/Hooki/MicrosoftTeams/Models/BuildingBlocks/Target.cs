using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Target
{
    [JsonPropertyName("os")] public string OperatingSystem { get; set; } = default!;

    [JsonPropertyName("uri")] public string Uri { get; set; } = default!;
}