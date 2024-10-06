using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class DividerBlockBuilder : BlockBaseBuilder
{
    public override BlockBase Build()
    {
        return new DividerBlock
        {
            BlockId = base.Build().BlockId
        };
    }
}