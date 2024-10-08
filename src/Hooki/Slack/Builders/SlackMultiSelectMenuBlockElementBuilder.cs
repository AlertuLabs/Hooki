using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackMultiSelectMenuBlockElementBuilder
{
    private SlackTextObject? _placeholder;
    private readonly List<SlackOptionObject> _options = [];
    private readonly List<SlackOptionObject> _initialOptions = [];
    private readonly List<SlackOptionGroupObject> _optionGroups = [];
    private SlackConfirmDialogObject? _confirm;
    private bool? _focusOnLoad;
    private int? _maxSelectedItems;
    private string? _actionId;

    public SlackMultiSelectMenuBlockElementBuilder WithActionId(string actionId)
    {
        _actionId = actionId;
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder WithPlaceholder(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _placeholder = builder.Build();
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder AddOption(SlackOptionObject slackOption)
    {
        _options.Add(slackOption);
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder AddInitialOption(SlackOptionObject slackOption)
    {
        _initialOptions.Add(slackOption);
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder AddOptionGroup(SlackOptionGroupObject slackOptionGroup)
    {
        _optionGroups.Add(slackOptionGroup);
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder WithConfirm(SlackConfirmDialogObject slackConfirm)
    {
        _confirm = slackConfirm;
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder WithFocusOnLoad(bool focusOnLoad)
    {
        _focusOnLoad = focusOnLoad;
        return this;
    }

    public SlackMultiSelectMenuBlockElementBuilder WithMaxSelectedItems(int maxSelectedItems)
    {
        _maxSelectedItems = maxSelectedItems;
        return this;
    }

    public ISlackActionBlockElement Build()
    {
        if (_options.Count == 0 && _optionGroups.Count == 0)
            throw new InvalidOperationException("Either options or option groups must be provided for a MultiSelectMenuElement.");

        return new SlackMultiSelectMenuElement
        {
            ActionId = _actionId,
            Placeholder = _placeholder,
            Options = (_options.Count > 0 ? _options.ToArray() : null) ?? Array.Empty<SlackOptionObject>(),
            InitialOptions = _initialOptions.Count > 0 ? _initialOptions.ToArray() : null,
            OptionGroups = _optionGroups.Count > 0 ? _optionGroups.ToArray() : null,
            Confirm = _confirm,
            FocusOnLoad = _focusOnLoad,
            MaxSelectedItems = _maxSelectedItems
        };
    }
}