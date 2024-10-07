using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#context
/// </summary>
public class ContextBlock : BlockBase
{
    [JsonPropertyName("type")] public override BlockType Type => BlockType.ContextBlock;
    
    [JsonConverter(typeof(ContextBlockElementConverter))] [JsonPropertyName("elements")] public required List<IContextBlockElement> Elements { get; set; }
}

public interface IContextBlockElement { }