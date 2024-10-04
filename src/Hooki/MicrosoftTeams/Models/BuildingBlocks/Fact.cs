using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Fact
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("value")] public required string Value { get; set; }
}