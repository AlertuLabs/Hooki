using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#divider
/// </summary>
public class SlackDividerBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.DividerBlock;
}