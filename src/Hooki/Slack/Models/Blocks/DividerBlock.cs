using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#divider
/// </summary>
public class DividerBlock : BlockBase
{
    public override BlockType Type => BlockType.DividerBlock;
}