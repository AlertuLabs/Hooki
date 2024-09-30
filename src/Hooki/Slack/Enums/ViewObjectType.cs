using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

public enum ViewObjectType
{
    [JsonPropertyName("modal")]
    Modal,
    [JsonPropertyName("home")]
    Home
}