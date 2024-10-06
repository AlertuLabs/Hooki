using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class RichTextBlockBuilder : BlockBaseBuilder
{
    private readonly List<IRichTextBlockElement> _elements = new();

    public RichTextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IRichTextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public override BlockBase Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextBlock.");

        return new RichTextBlock
        {
            BlockId = base.Build().BlockId,
            Elements = _elements
        };
    }
}