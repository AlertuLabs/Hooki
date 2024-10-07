using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class MultiSelectMenuBlockElementBuilder
{
    private TextObject? _placeholder;
    private readonly List<OptionObject> _options = [];
    private readonly List<OptionObject> _initialOptions = [];
    private readonly List<OptionGroupObject> _optionGroups = [];
    private ConfirmationDialogObject? _confirm;
    private bool? _focusOnLoad;
    private int? _maxSelectedItems;
    private string? _actionId;

    public MultiSelectMenuBlockElementBuilder WithActionId(string actionId)
    {
        _actionId = actionId;
        return this;
    }

    public MultiSelectMenuBlockElementBuilder WithPlaceholder(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _placeholder = builder.Build();
        return this;
    }

    public MultiSelectMenuBlockElementBuilder AddOption(OptionObject option)
    {
        _options.Add(option);
        return this;
    }

    public MultiSelectMenuBlockElementBuilder AddInitialOption(OptionObject option)
    {
        _initialOptions.Add(option);
        return this;
    }

    public MultiSelectMenuBlockElementBuilder AddOptionGroup(OptionGroupObject optionGroup)
    {
        _optionGroups.Add(optionGroup);
        return this;
    }

    public MultiSelectMenuBlockElementBuilder WithConfirm(ConfirmationDialogObject confirmation)
    {
        _confirm = confirmation;
        return this;
    }

    public MultiSelectMenuBlockElementBuilder WithFocusOnLoad(bool focusOnLoad)
    {
        _focusOnLoad = focusOnLoad;
        return this;
    }

    public MultiSelectMenuBlockElementBuilder WithMaxSelectedItems(int maxSelectedItems)
    {
        _maxSelectedItems = maxSelectedItems;
        return this;
    }

    public IActionBlockElement Build()
    {
        if (_options.Count == 0 && _optionGroups.Count == 0)
            throw new InvalidOperationException("Either options or option groups must be provided for a MultiSelectMenuElement.");

        return new MultiSelectMenuElement
        {
            ActionId = _actionId,
            Placeholder = _placeholder,
            Options = (_options.Count > 0 ? _options.ToArray() : null) ?? Array.Empty<OptionObject>(),
            InitialOptions = _initialOptions.Count > 0 ? _initialOptions.ToArray() : null,
            OptionGroups = _optionGroups.Count > 0 ? _optionGroups.ToArray() : null,
            Confirm = _confirm,
            FocusOnLoad = _focusOnLoad,
            MaxSelectedItems = _maxSelectedItems
        };
    }
}