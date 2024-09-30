using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.ViewObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#confirm
/// </summary>
public class HomeTab
{
    [JsonPropertyName("type")] public static ViewObjectType Type => ViewObjectType.Home;
    
    [JsonPropertyName("blocks")] public required BlockBase[] Blocks { get; set; }
    
    [JsonPropertyName("private_metadata")] public string? PrivateMetadata { get; set; }
    
    [JsonPropertyName("callback_id")] public string? CallbackId { get; set; }
    
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
}