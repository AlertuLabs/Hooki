using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text
/// </summary>
public class RichTextBlock : BlockBase
{
    [JsonPropertyName("type")] public BlockType Type => BlockType.RichTextBlock;
    
    [JsonPropertyName("elements")] public required IRichTextBlockElement[] Elements { get; set; }
}

public interface IRichTextBlockElement { }

public interface IRichTextElement { }

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_section
/// </summary>
public class RichTextSection : IRichTextBlockElement
{
    [JsonPropertyName("type")] public const RichTextBlockElementType Type = RichTextBlockElementType.RichTextSection;
    
    [JsonPropertyName("elements")] public required IRichTextElement[] Elements { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_list
/// </summary>
public class RichTextList : IRichTextBlockElement
{
    [JsonPropertyName("type")] public const RichTextBlockElementType Type = RichTextBlockElementType.RichTextList;
    
    [JsonPropertyName("style")] public required RichTextListStyleType Style { get; set; }
    
    [JsonPropertyName("elements")] public required IRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("indent")] public int? Indent { get; set; }
    
    [JsonPropertyName("offset")] public int? Offset { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_preformatted
/// </summary>
public class RichTextPreformatted : IRichTextBlockElement
{
    [JsonPropertyName("type")] public const RichTextBlockElementType Type = RichTextBlockElementType.RichTextPreformatted;
    
    [JsonPropertyName("elements")] public required IRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_quote
/// </summary>
public class RichTextQuote : IRichTextBlockElement
{
    [JsonPropertyName("type")] public const RichTextBlockElementType Type = RichTextBlockElementType.RichTextQuote;
    
    [JsonPropertyName("elements")] public required IRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}