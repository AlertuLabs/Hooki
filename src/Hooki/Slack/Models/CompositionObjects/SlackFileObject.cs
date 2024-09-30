using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#slack_file
/// </summary>
public class SlackFileObject
{
    [JsonPropertyName("url")] public string? Url { get; set; }
    
    [JsonPropertyName("id")] public string? Id { get; set; }
}