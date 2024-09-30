using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#input
/// </summary>
public class InputBlock : BlockBase
{
    public override BlockType Type => BlockType.InputBlock;
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("label")] public required TextObject Label { get; set; }
    
    [JsonPropertyName("element")] public required TextObject Element { get; set; }
    
    [JsonPropertyName("dispatch_action")] public bool? DispatchAction { get; set; }
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("hint")] public TextObject? Hint { get; set; }
    
    [JsonPropertyName("optional")] public bool? Optional { get; set; }
}