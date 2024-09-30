using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Please note that while none of the fields above are individually required, you must supply at least one of these fields.
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#filter_conversations
/// </summary>
public class ConversationFilterObject
{
    [JsonPropertyName("include")] public string[]? Include { get; set; }
    
    [JsonPropertyName("exclude_external_shared_channels")] public bool? ExcludeExternalSharedChannels { get; set; }
    
    [JsonPropertyName("exclude_bot_users")] public bool? ExcludeBotUsers { get; set; }
}