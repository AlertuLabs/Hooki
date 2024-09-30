using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#actions
/// </summary>
public class ActionBlock : BlockBase
{
    public override BlockType Type => BlockType.ActionBlock;

    [JsonPropertyName("elements")]
    public required List<BlockElementBase> Elements { get; set; }
}