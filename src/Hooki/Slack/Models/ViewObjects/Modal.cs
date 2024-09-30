using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.ViewObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/surfaces/views#modal
/// </summary>
public class Modal
{
    [JsonPropertyName("type")] public static ViewObjectType Type => ViewObjectType.Modal;

    [JsonPropertyName("title")] public required TextObject Title { get; set; }
    
    [JsonPropertyName("blocks")] public required BlockBase[] Blocks { get; set; }
    
    /// <summary>
    /// When provided, TextObject must be of type PlainText
    /// </summary>
    [JsonPropertyName("close")] public TextObject? Close { get; set; }
    
    /// <summary>
    /// When provided, TextObject must be of type PlainText
    /// </summary>
    [JsonPropertyName("submit")] public TextObject? Submit { get; set; }
    
    [JsonPropertyName("private_metadata")] public string? PrivateMetadata { get; set; }
    
    [JsonPropertyName("callback_id")] public string? CallBackId { get; set; }
    
    [JsonPropertyName("clear_on_close")] public bool? ClearOnClose { get; set; }
    
    [JsonPropertyName("notify_on_close")] public bool? NotifyOnClose { get; set; }
    
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    
    [JsonPropertyName("submit_disabled")] public bool? SubmitDisabled { get; set; }
}