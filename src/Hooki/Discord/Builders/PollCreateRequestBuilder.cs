using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class PollCreateRequestBuilder
{
    private PollMedia? _question;
    private readonly List<PollAnswer> _answers = new();
    private int? _duration;
    private bool? _allowMultiSelect;
    private int? _layoutType;

    public PollCreateRequestBuilder WithQuestion(Action<PollMediaBuilder> buildAction)
    {
        var builder = new PollMediaBuilder();
        buildAction(builder);
        _question = builder.Build();
        return this;
    }

    public PollCreateRequestBuilder AddAnswer(Action<PollAnswerBuilder> buildAction)
    {
        var builder = new PollAnswerBuilder();
        buildAction(builder);
        _answers.Add(builder.Build());
        return this;
    }

    public PollCreateRequestBuilder WithDuration(int duration)
    {
        _duration = duration;
        return this;
    }

    public PollCreateRequestBuilder AllowMultiSelect(bool allow = true)
    {
        _allowMultiSelect = allow;
        return this;
    }

    public PollCreateRequestBuilder WithLayoutType(int layoutType)
    {
        _layoutType = layoutType;
        return this;
    }

    public PollCreateRequest Build()
    {
        if (_question == null)
            throw new InvalidOperationException("Question is required.");
        if (_answers.Count == 0)
            throw new InvalidOperationException("At least one answer is required.");

        return new PollCreateRequest
        {
            Question = _question,
            Answers = _answers,
            Duration = _duration,
            AllowMultiSelect = _allowMultiSelect,
            LayoutType = _layoutType
        };
    }
}

public class PollMediaBuilder
{
    private string? _text;
    private Emoji? _emoji;

    public PollMediaBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public PollMediaBuilder WithEmoji(Action<EmojiBuilder> buildAction)
    {
        var builder = new EmojiBuilder();
        buildAction(builder);
        _emoji = builder.Build();
        return this;
    }

    public PollMedia Build()
    {
        if (string.IsNullOrWhiteSpace(_text))
            throw new InvalidOperationException("Text is required for PollMedia.");

        return new PollMedia
        {
            Text = _text,
            Emoji = _emoji
        };
    }
}

public class PollAnswerBuilder
{
    private int? _answerId;
    private PollMedia? _pollMedia;

    public PollAnswerBuilder WithAnswerId(int answerId)
    {
        _answerId = answerId;
        return this;
    }

    public PollAnswerBuilder WithPollMedia(Action<PollMediaBuilder> buildAction)
    {
        var builder = new PollMediaBuilder();
        buildAction(builder);
        _pollMedia = builder.Build();
        return this;
    }

    public PollAnswer Build()
    {
        if (_pollMedia == null)
            throw new InvalidOperationException("PollMedia is required for PollAnswer.");

        return new PollAnswer
        {
            AnswerId = _answerId,
            PollMedia = _pollMedia
        };
    }
}

public class EmojiBuilder
{
    private string? _id;
    private string? _name;

    public EmojiBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public EmojiBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public Emoji Build()
    {
        if (string.IsNullOrWhiteSpace(_id) && string.IsNullOrWhiteSpace(_name))
            throw new InvalidOperationException("Either Id or Name must be provided for Emoji.");

        return new Emoji
        {
            Id = _id,
            Name = _name
        };
    }
}