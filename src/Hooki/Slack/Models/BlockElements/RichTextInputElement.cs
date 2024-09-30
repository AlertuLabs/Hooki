using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#rich_text_input
/// </summary>
public class RichTextInputElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.RichTextInput;

    [JsonPropertyName("initial_value")]
    public RichTextBlock? InitialValue { get; set; }

    [JsonPropertyName("dispatch_action_config")]
    public DispatchActionConfigurationObject? DispatchActionConfig { get; set; }

    [JsonPropertyName("focus_on_load")]
    public bool? FocusOnLoad { get; set; }

    [JsonPropertyName("placeholder")]
    public TextObject? Placeholder { get; set; }
}