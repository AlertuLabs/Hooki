using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SectionBlockBuilder : IBlockBuilder
{
    private TextObject? _text;
    private List<TextObject>? _fields;
    private ISectionBlockElement? _accessory;
    private bool? _expand;
    private string? _blockId;

    public SectionBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public SectionBlockBuilder WithText(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _text = builder.Build();
        return this;
    }

    public SectionBlockBuilder AddField(Action<TextObjectBuilder> buildAction)
    {
        _fields ??= new List<TextObject>();
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _fields.Add(builder.Build());
        return this;
    }

    public SectionBlockBuilder WithAccessory<T>(Func<T> accessoryFactory) where T : ISectionBlockElement
    {
        _accessory = accessoryFactory();
        return this;
    }

    public SectionBlockBuilder WithExpand(bool expand)
    {
        _expand = expand;
        return this;
    }

    public BlockBase Build()
    {
        if (_text == null && (_fields == null || _fields.Count == 0))
            throw new InvalidOperationException("Either text or at least one field is required for a SectionBlock.");

        return new SectionBlock
        {
            BlockId = _blockId,
            Text = _text,
            Fields = _fields?.ToArray(),
            Accessory = _accessory,
            Expand = _expand
        };
    }
}