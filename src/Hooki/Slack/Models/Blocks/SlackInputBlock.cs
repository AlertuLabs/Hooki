using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#input
/// </summary>
public class SlackInputBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.InputBlock;
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("label")] public required SlackTextObject Label { get; set; }
    
    [JsonConverter(typeof(SlackInputBlockElementConverter))] [JsonPropertyName("element")] public required IInputBlockElement Element { get; set; }
    
    [JsonPropertyName("dispatch_action")] public bool? DispatchAction { get; set; }
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("hint")] public SlackTextObject? Hint { get; set; }
    
    [JsonPropertyName("optional")] public bool? Optional { get; set; }
}

public interface IInputBlockElement { }