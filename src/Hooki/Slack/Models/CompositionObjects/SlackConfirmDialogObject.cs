using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#confirm
/// </summary>
public class SlackConfirmDialogObject
{
    [JsonPropertyName("title")] public required SlackTextObject Title { get; set; }
    
    [JsonPropertyName("text")] public required SlackTextObject SlackText { get; set; }
    
    [JsonPropertyName("confirm")] public required SlackTextObject Confirm { get; set; }
    
    [JsonPropertyName("deny")] public required SlackTextObject Deny { get; set; }
    
    [JsonPropertyName("style")] public string? Style { get; set; }
}