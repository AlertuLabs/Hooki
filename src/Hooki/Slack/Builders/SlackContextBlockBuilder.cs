using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackContextBlockBuilder : ISlackBlockBuilder
{
    private readonly List<ISlackContextBlockElement> _elements = new();
    private string? _blockId;

    public SlackContextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : ISlackContextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public SlackContextBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public SlackBlock Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for an ActionBlock.");

        return new SlackContextBlock
        {
            BlockId = _blockId,
            Elements = _elements
        };
    }
}