using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackInputBlockBuilder : ISlackBlockBuilder
{
    private SlackTextObject? _label;
    private IInputBlockElement? _element;
    private bool? _dispatchAction;
    private SlackTextObject? _hint;
    private bool? _optional;
    private string? _blockId;

    public SlackInputBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackInputBlockBuilder WithLabel(SlackTextObject label)
    {
        _label = label;
        return this;
    }
    
    public SlackInputBlockBuilder WithElement<T>(Func<T> elementFactory) where T : IInputBlockElement
    {
        _element = elementFactory();
        return this;
    }
    
    public SlackInputBlockBuilder WithDispatchAction(bool dispatchAction)
    {
        _dispatchAction = dispatchAction;
        return this;
    }
    
    public SlackInputBlockBuilder WithHint(SlackTextObject hint)
    {
        _hint = hint;
        return this;
    }
    
    public SlackInputBlockBuilder WithOptional(bool optional)
    {
        _optional = optional;
        return this;
    }
    
    public SlackBlock Build()
    {
        if (_label is null)
            throw new InvalidOperationException("Label must have a value");

        if (_element is null)
            throw new InvalidOperationException("Element must have a value");
        
        return new SlackInputBlock
        {
            BlockId = _blockId,
            Label = _label,
            Element = _element,
            DispatchAction = _dispatchAction,
            Hint = _hint,
            Optional = _optional
        };
    }
}