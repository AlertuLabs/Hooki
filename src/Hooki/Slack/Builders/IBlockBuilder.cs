using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public interface IBlockBuilder
{
    BlockBase Build();
}