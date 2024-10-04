using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Image
{
    [JsonPropertyName("image")] public required string ImageUrl { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }
}