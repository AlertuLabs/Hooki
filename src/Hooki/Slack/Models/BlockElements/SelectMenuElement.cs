using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#static_select
/// </summary>
public class SelectMenuElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.SelectMenu;

    [JsonPropertyName("options")] public required OptionObject[] Options { get; set; }
    
    [JsonPropertyName("option_groups")] public OptionGroupObject[]? OptionGroups { get; set; }
    
    [JsonPropertyName("initial_option")] public OptionObject? InitialOption { get; set; }
    
    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }
    
    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
    
    [JsonPropertyName("placeholder")] public TextObject? Placeholder { get; set; }
}