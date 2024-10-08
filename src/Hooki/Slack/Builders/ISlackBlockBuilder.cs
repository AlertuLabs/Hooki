using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public interface ISlackBlockBuilder
{
    SlackBlock Build();
}