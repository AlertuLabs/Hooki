using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class ContextBlockBuilder : IBlockBuilder
{
    private readonly List<IContextBlockElement> _elements = new();
    private string? _blockId;

    public ContextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IContextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public ContextBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public BlockBase Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for an ActionBlock.");

        return new ContextBlock
        {
            BlockId = _blockId,
            Elements = _elements
        };
    }
}