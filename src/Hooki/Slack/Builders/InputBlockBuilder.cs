using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class InputBlockBuilder : BlockBaseBuilder
{
    private TextObject? _label;
    private IInputBlockElement? _element;
    private bool? _dispatchAction;
    private TextObject? _hint;
    private bool? _optional;
    
    public InputBlockBuilder WithLabel(TextObject label)
    {
        _label = label;
        return this;
    }
    
    public InputBlockBuilder WithElement<T>(Func<T> elementFactory) where T : IInputBlockElement
    {
        _element = elementFactory();
        return this;
    }
    
    public InputBlockBuilder WithDispatchAction(bool dispatchAction)
    {
        _dispatchAction = dispatchAction;
        return this;
    }
    
    public InputBlockBuilder WithHint(TextObject hint)
    {
        _hint = hint;
        return this;
    }
    
    public InputBlockBuilder WithOptional(bool optional)
    {
        _optional = optional;
        return this;
    }
    
    public override InputBlock Build()
    {
        if (_label is null)
            throw new InvalidOperationException("Label must have a value");

        if (_element is null)
            throw new InvalidOperationException("Element must have a value");
        
        return new InputBlock
        {
            BlockId = base.Build().BlockId,
            Label = _label,
            Element = _element,
            DispatchAction = _dispatchAction,
            Hint = _hint,
            Optional = _optional
        };
    }
}