using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#url
/// </summary>
public class SlackUrlInputElement : SlackBlockElement, IInputBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.UrlInput;

    [JsonPropertyName("initial_value")] public string? InitialValue { get; set; }

    [JsonPropertyName("dispatch_action_config")] public SlackDispatchActionConfigObject? DispatchActionConfig { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    [JsonPropertyName("placeholder")] public SlackTextObject? Placeholder { get; set; }
}