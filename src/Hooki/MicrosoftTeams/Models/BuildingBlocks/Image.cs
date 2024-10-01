using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Image
{
    [JsonPropertyName("image")] public string ImageUrl { get; set; } = default!;

    [JsonPropertyName("title")] public string Title { get; set; } = default!;
}