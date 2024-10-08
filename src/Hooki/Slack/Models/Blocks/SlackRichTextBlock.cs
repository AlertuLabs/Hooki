using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text
/// </summary>
public class SlackRichTextBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.RichTextBlock;
    
    [JsonPropertyName("elements")] public required List<ISlackRichTextBlockElement> Elements { get; set; }
}

public interface ISlackRichTextBlockElement { }

public interface ISlackRichTextElement { }

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_section
/// </summary>
public class SlackRichTextSection : ISlackRichTextBlockElement
{
    [JsonPropertyName("type")] public const SlackRichTextBlockElementType Type = SlackRichTextBlockElementType.RichTextSection;
    
    [JsonPropertyName("elements")] public required ISlackRichTextElement[] Elements { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_list
/// </summary>
public class SlackRichTextList : ISlackRichTextBlockElement
{
    [JsonPropertyName("type")] public const SlackRichTextBlockElementType Type = SlackRichTextBlockElementType.RichTextList;
    
    [JsonPropertyName("style")] public required SlackRichTextListStyle Style { get; set; }
    
    [JsonPropertyName("elements")] public required ISlackRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("indent")] public int? Indent { get; set; }
    
    [JsonPropertyName("offset")] public int? Offset { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_preformatted
/// </summary>
public class SlackRichTextPreformatted : ISlackRichTextBlockElement
{
    [JsonPropertyName("type")] public const SlackRichTextBlockElementType Type = SlackRichTextBlockElementType.RichTextPreformatted;
    
    [JsonPropertyName("elements")] public required ISlackRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#rich_text_quote
/// </summary>
public class SlackRichTextQuote : ISlackRichTextBlockElement
{
    [JsonPropertyName("type")] public const SlackRichTextBlockElementType Type = SlackRichTextBlockElementType.RichTextQuote;
    
    [JsonPropertyName("elements")] public required ISlackRichTextElement[] Elements { get; set; }
    
    [JsonPropertyName("border")] public int? Border { get; set; }
}