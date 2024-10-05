using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#multi_select
/// </summary>
public class MultiSelectMenuElement : BlockElementBase, IActionBlockElement, IInputBlockElement, ISectionBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.MultiSelectMenu;

    [JsonPropertyName("placeholder")] public TextObject? Placeholder { get; set; }

    [JsonPropertyName("options")] public required OptionObject[] Options { get; set; }
    
    [JsonPropertyName("initial_options")] public OptionObject[]? InitialOptions { get; set; }

    [JsonPropertyName("option_groups")] public OptionGroupObject[]? OptionGroups { get; set; }
    
    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
    
    [JsonPropertyName("max_selected_items")] public int? MaxSelectedItems { get; set; }
    
    // User list properties
    [JsonPropertyName("min_query_length")] public int? MinQueryLength { get; set; }
    
    [JsonPropertyName("initial_users")] public string[]? InitialUsers { get; set; }
    
    // Conversations list properties
    [JsonPropertyName("initial_conversations")] public string[]? InitialConversations { get; set; }
    [JsonPropertyName("default_to_current_conversation")] public bool? DefaultToCurrentConversation { get; set; }
    [JsonPropertyName("filter")] public ConversationFilterObject? Filter { get; set; }
    
    // Public channel list properties
    [JsonPropertyName("initial_channels")] public string[]? InitialChannels { get; set; }
}