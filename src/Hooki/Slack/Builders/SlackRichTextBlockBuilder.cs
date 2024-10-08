using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackRichTextBlockBuilder : ISlackBlockBuilder
{
    private readonly List<ISlackRichTextBlockElement> _elements = new();
    private string? _blockId;

    public SlackRichTextBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackRichTextBlockBuilder AddElement<T>(Func<T> elementFactory) where T : ISlackRichTextBlockElement
    {
        _elements.Add(elementFactory());
        return this;
    }

    public SlackBlock Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextBlock.");

        return new SlackRichTextBlock
        {
            BlockId = _blockId,
            Elements = _elements
        };
    }
}