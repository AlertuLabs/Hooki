using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#email
/// </summary>
public class EmailInputElement : BlockElementBase, IInputBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.EmailInput;

    [JsonPropertyName("initial_value")] public string? InitialValue { get; set; }

    [JsonPropertyName("dispatch_action_config")] public DispatchActionConfigurationObject? DispatchActionConfig { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    [JsonPropertyName("placeholder")] public TextObject? Placeholder { get; set; }
}