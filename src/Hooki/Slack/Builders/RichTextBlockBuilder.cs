using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class RichTextBlockBuilder : IBlockBuilder
{
    private readonly List<IRichTextBlockElement> _elements = new();
    private string? _blockId;

    public RichTextBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public RichTextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IRichTextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public BlockBase Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextBlock.");

        return new RichTextBlock
        {
            BlockId = _blockId,
            Elements = _elements
        };
    }
}