using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class EmbedBuilder
{
    private string? _title;
    private string? _description;
    private string? _url;
    private DateTimeOffset? _timestamp;
    private int? _color;
    private EmbedFooter? _footer;
    private EmbedImage? _image;
    private EmbedThumbnail? _thumbnail;
    private EmbedAuthor? _author;
    private List<EmbedField>? _fields;

    public EmbedBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public EmbedBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public EmbedBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public EmbedBuilder WithTimestamp(DateTimeOffset timestamp)
    {
        _timestamp = timestamp;
        return this;
    }

    public EmbedBuilder WithColor(int color)
    {
        _color = color;
        return this;
    }

    public EmbedBuilder WithFooter(string text, string? iconUrl = null)
    {
        _footer = new EmbedFooter { Text = text, IconUrl = iconUrl };
        return this;
    }

    public EmbedBuilder WithImage(string url)
    {
        _image = new EmbedImage { Url = url };
        return this;
    }

    public EmbedBuilder WithThumbnail(string url)
    {
        _thumbnail = new EmbedThumbnail { Url = url };
        return this;
    }

    public EmbedBuilder WithAuthor(string name, string? url = null, string? iconUrl = null)
    {
        _author = new EmbedAuthor { Name = name, Url = url, IconUrl = iconUrl };
        return this;
    }

    public EmbedBuilder AddField(string name, string value, bool? inline = null)
    {
        _fields ??= [];
        _fields.Add(new EmbedField { Name = name, Value = value, Inline = inline });
        return this;
    }

    public Embed Build()
    {
        return new Embed
        {
            Title = _title,
            Description = _description,
            Url = _url,
            Timestamp = _timestamp,
            Color = _color,
            Footer = _footer,
            Image = _image,
            Thumbnail = _thumbnail,
            Author = _author,
            Fields = _fields
        };
    }
}