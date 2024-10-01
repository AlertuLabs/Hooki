using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text
/// </summary>
public class RichTextBlock : BlockBase
{
    public override BlockType Type => BlockType.RichTextBlock;
    
    [JsonPropertyName("elements")]
    public required object[] Elements { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_section
/// </summary>
public class RichTextSection
{
    [JsonPropertyName("type")]
    public const RichTextObjectTypes Type = RichTextObjectTypes.RichTextSection;
    
    //ToDo: Implement Rich element types for type safety and validation: https://api.slack.com/reference/block-kit/blocks#broadcast-element-type
    [JsonPropertyName("elements")]
    public required object[] Elements { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_list
/// </summary>
public class RichTextList
{
    [JsonPropertyName("type")]
    public const RichTextObjectTypes Type = RichTextObjectTypes.RichTextList;
    
    [JsonPropertyName("style")]
    public required RichTextListStyleTypes Style { get; set; }
    
    //ToDo: Implement Rich element types for type safety and validation: https://api.slack.com/reference/block-kit/blocks#broadcast-element-type
    [JsonPropertyName("elements")]
    public required object[] Elements { get; set; }
    
    [JsonPropertyName("indent")]
    public int? Indent { get; set; }
    
    [JsonPropertyName("offset")]
    public int? Offset { get; set; }
    
    [JsonPropertyName("border")]
    public int? Border { get; set; }
}

public enum RichTextListStyleTypes
{
    [JsonPropertyName("bullet")]
    Bullet,
    [JsonPropertyName("ordered")]
    Ordered
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_preformatted
/// </summary>
public class RichTextPreformatted
{
    [JsonPropertyName("type")]
    public const RichTextObjectTypes Type = RichTextObjectTypes.RichTextPreformatted;
    
    //ToDo: Implement Rich element types for type safety and validation: https://api.slack.com/reference/block-kit/blocks#broadcast-element-type
    [JsonPropertyName("elements")]
    public required object[] Elements { get; set; }
    
    [JsonPropertyName("border")]
    public int? Border { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_quote
/// </summary>
public class RichTextQuote
{
    [JsonPropertyName("type")]
    public const RichTextObjectTypes Type = RichTextObjectTypes.RichTextQuote;
    
    //ToDo: Implement Rich element types for type safety and validation: https://api.slack.com/reference/block-kit/blocks#broadcast-element-type
    [JsonPropertyName("elements")]
    public required object[] Elements { get; set; }
    
    [JsonPropertyName("border")]
    public int? Border { get; set; }
}