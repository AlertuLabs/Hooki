using System.Text.Json.Serialization;

namespace Alertu.ThirdPartyAlertNotificationProcessor.Pocos.MicrosoftTeams.BuildingBlocks;

public class Image
{
    [JsonPropertyName("image")] public string ImageUrl { get; set; } = default!;

    [JsonPropertyName("title")] public string Title { get; set; } = default!;
}