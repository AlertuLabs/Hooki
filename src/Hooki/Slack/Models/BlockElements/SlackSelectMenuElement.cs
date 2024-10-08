using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#static_select
/// </summary>
public class SlackSelectMenuElement : SlackBlockElement, ISlackActionBlockElement, IInputBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.SelectMenu;

    [JsonPropertyName("options")] public required SlackOptionObject[] Options { get; set; }
    
    [JsonPropertyName("option_groups")] public SlackOptionGroupObject[]? OptionGroups { get; set; }
    
    [JsonPropertyName("initial_option")] public SlackOptionObject? InitialOption { get; set; }
    
    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }
    
    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
    
    [JsonPropertyName("placeholder")] public SlackTextObject? Placeholder { get; set; }
}