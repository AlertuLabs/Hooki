using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

/// <summary>
/// Refer to Microsoft Team's documentation for more details: https://learn.microsoft.com/en-us/outlook/actionable-messages/message-card-reference#openuri-action
/// </summary>
public class Image
{
    [JsonPropertyName("image")] public required string ImageUrl { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }
}