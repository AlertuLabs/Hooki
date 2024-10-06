using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class ContextBlockBuilder : BlockBaseBuilder
{
    private readonly List<IContextBlockElement> _elements = new();

    public ContextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IContextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public override BlockBase Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for an ActionBlock.");

        return new ContextBlock
        {
            BlockId = base.Build().BlockId,
            Elements = _elements
        };
    }
}