using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class RichTextBlockBuilder : BlockBaseBuilder
{
    private readonly List<IRichTextBlockElement> _elements = new();

    public RichTextBlockBuilder AddElement(IRichTextBlockElement element)
    {
        _elements.Add(element);
        return this;
    }

    public RichTextBlockBuilder AddElements(IEnumerable<IRichTextBlockElement> elements)
    {
        _elements.AddRange(elements);
        return this;
    }

    public RichTextBlockBuilder WithElements(Action<RichTextElementsBuilder> buildAction)
    {
        var builder = new RichTextElementsBuilder();
        buildAction(builder);
        _elements.AddRange(builder.Build());
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

public class RichTextElementsBuilder
{
    private readonly List<IRichTextBlockElement> _elements = new();

    public RichTextElementsBuilder AddSection(Action<RichTextSectionBuilder> buildAction)
    {
        var builder = new RichTextSectionBuilder();
        buildAction(builder);
        _elements.Add(builder.Build());
        return this;
    }

    public RichTextElementsBuilder AddList(Action<RichTextListBuilder> buildAction)
    {
        var builder = new RichTextListBuilder();
        buildAction(builder);
        _elements.Add(builder.Build());
        return this;
    }

    public RichTextElementsBuilder AddPreformatted(Action<RichTextPreformattedBuilder> buildAction)
    {
        var builder = new RichTextPreformattedBuilder();
        buildAction(builder);
        _elements.Add(builder.Build());
        return this;
    }

    public RichTextElementsBuilder AddQuote(Action<RichTextQuoteBuilder> buildAction)
    {
        var builder = new RichTextQuoteBuilder();
        buildAction(builder);
        _elements.Add(builder.Build());
        return this;
    }

    public IEnumerable<IRichTextBlockElement> Build() => _elements;
}

public class RichTextSectionBuilder
{
    private readonly List<IRichTextElement> _elements = new();

    public RichTextSectionBuilder AddElement(IRichTextElement element)
    {
        _elements.Add(element);
        return this;
    }

    public RichTextSection Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextSection.");

        return new RichTextSection
        {
            Elements = _elements.ToArray()
        };
    }
}

public class RichTextListBuilder
{
    private RichTextListStyleType _style;
    private readonly List<IRichTextElement> _elements = new();
    private int? _indent;
    private int? _offset;
    private int? _border;

    public RichTextListBuilder WithStyle(RichTextListStyleType style)
    {
        _style = style;
        return this;
    }

    public RichTextListBuilder AddElement(IRichTextElement element)
    {
        _elements.Add(element);
        return this;
    }

    public RichTextListBuilder WithIndent(int indent)
    {
        _indent = indent;
        return this;
    }

    public RichTextListBuilder WithOffset(int offset)
    {
        _offset = offset;
        return this;
    }

    public RichTextListBuilder WithBorder(int border)
    {
        _border = border;
        return this;
    }

    public RichTextList Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextList.");

        return new RichTextList
        {
            Style = _style,
            Elements = _elements.ToArray(),
            Indent = _indent,
            Offset = _offset,
            Border = _border
        };
    }
}

public class RichTextPreformattedBuilder
{
    private readonly List<IRichTextElement> _elements = new();
    private int? _border;

    public RichTextPreformattedBuilder AddElement(IRichTextElement element)
    {
        _elements.Add(element);
        return this;
    }

    public RichTextPreformattedBuilder WithBorder(int border)
    {
        _border = border;
        return this;
    }

    public RichTextPreformatted Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextPreformatted.");

        return new RichTextPreformatted
        {
            Elements = _elements.ToArray(),
            Border = _border
        };
    }
}

public class RichTextQuoteBuilder
{
    private readonly List<IRichTextElement> _elements = new();
    private int? _border;

    public RichTextQuoteBuilder AddElement(IRichTextElement element)
    {
        _elements.Add(element);
        return this;
    }

    public RichTextQuoteBuilder WithBorder(int border)
    {
        _border = border;
        return this;
    }

    public RichTextQuote Build()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("At least one element is required for a RichTextQuote.");

        return new RichTextQuote
        {
            Elements = _elements.ToArray(),
            Border = _border
        };
    }
}