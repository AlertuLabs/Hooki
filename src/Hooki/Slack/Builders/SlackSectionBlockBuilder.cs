using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackSectionBlockBuilder : ISlackBlockBuilder
{
    private SlackTextObject? _text;
    private List<SlackTextObject>? _fields;
    private ISlackSectionBlockElement? _accessory;
    private bool? _expand;
    private string? _blockId;

    public SlackSectionBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public SlackSectionBlockBuilder WithText(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _text = builder.Build();
        return this;
    }

    public SlackSectionBlockBuilder AddField(Action<SlackTextObjectBuilder> buildAction)
    {
        _fields ??= new List<SlackTextObject>();
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _fields.Add(builder.Build());
        return this;
    }

    public SlackSectionBlockBuilder WithAccessory<T>(Func<T> accessoryFactory) where T : ISlackSectionBlockElement
    {
        _accessory = accessoryFactory();
        return this;
    }

    public SlackSectionBlockBuilder WithExpand(bool expand)
    {
        _expand = expand;
        return this;
    }

    public SlackBlock Build()
    {
        if (_text == null && (_fields == null || _fields.Count == 0))
            throw new InvalidOperationException("Either text or at least one field is required for a SectionBlock.");

        return new SlackSectionBlock
        {
            BlockId = _blockId,
            Text = _text,
            Fields = _fields?.ToArray(),
            Accessory = _accessory,
            Expand = _expand
        };
    }
}