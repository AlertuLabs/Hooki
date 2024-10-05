using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#context
/// </summary>
public class ContextBlock : BlockBase
{
    [JsonPropertyName("type")] public static BlockType Type => BlockType.ContextBlock;
    
    [JsonPropertyName("elements")] public required IContextBlockElement[] Elements { get; set; }
}

public interface IContextBlockElement { }