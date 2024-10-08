using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#section
/// </summary>
public class SlackSectionBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.SectionBlock;
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// This is a preferred field
    /// </summary>
    [JsonPropertyName("text")] public SlackTextObject? Text { get; set; }
    
    /// <summary>
    /// This is a maybe field
    /// Required if Text isn't provided
    /// </summary>
    [JsonPropertyName("fields")] public SlackTextObject[]? Fields { get; set; }
    
    [JsonPropertyName("accessory")] public ISlackSectionBlockElement? Accessory { get; set; }
    
    [JsonPropertyName("expand")] public bool? Expand { get; set; }
}

public interface ISlackSectionBlockElement { }