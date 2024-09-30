using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#section
/// </summary>
public class SectionBlock : BlockBase
{
    public override BlockType Type => BlockType.SectionBlock;
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// This is a preferred field
    /// </summary>
    [JsonPropertyName("text")] public TextObject? Text { get; set; }
    
    /// <summary>
    /// This is a maybe field
    /// </summary>
    [JsonPropertyName("fields")] public TextObject[]? Fields { get; set; }
    
    //ToDo: Add type safety for the compatible block elements 
    [JsonPropertyName("accessory")] public object? Accessory { get; set; }
    
    [JsonPropertyName("expand")] public bool? Expand { get; set; }
}