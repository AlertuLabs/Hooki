using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#confirm
/// </summary>
public class ConfirmationDialogObject
{
    [JsonPropertyName("title")] public required TextObject Title { get; set; }
    
    [JsonPropertyName("text")] public required TextObject Text { get; set; }
    
    [JsonPropertyName("confirm")] public required TextObject Confirm { get; set; }
    
    [JsonPropertyName("deny")] public required TextObject Deny { get; set; }
    
    [JsonPropertyName("style")] public string? Style { get; set; }
}