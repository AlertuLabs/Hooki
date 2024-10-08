using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class DiscordEmbedBuilder
{
    private string? _title;
    private string? _description;
    private string? _url;
    private DateTimeOffset? _timestamp;
    private int? _color;
    private DiscordEmbedFooter? _footer;
    private DiscordImbedImage? _image;
    private DiscordEmbedThumbnail? _thumbnail;
    private DiscordEmbedAuthor? _author;
    private List<DiscordEmbedField>? _fields;

    public DiscordEmbedBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public DiscordEmbedBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public DiscordEmbedBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public DiscordEmbedBuilder WithTimestamp(DateTimeOffset timestamp)
    {
        _timestamp = timestamp;
        return this;
    }

    public DiscordEmbedBuilder WithColor(int color)
    {
        _color = color;
        return this;
    }

    public DiscordEmbedBuilder WithFooter(string text, string? iconUrl = null)
    {
        _footer = new DiscordEmbedFooter { Text = text, IconUrl = iconUrl };
        return this;
    }

    public DiscordEmbedBuilder WithImage(string url)
    {
        _image = new DiscordImbedImage { Url = url };
        return this;
    }

    public DiscordEmbedBuilder WithThumbnail(string url)
    {
        _thumbnail = new DiscordEmbedThumbnail { Url = url };
        return this;
    }

    public DiscordEmbedBuilder WithAuthor(string name, string? url = null, string? iconUrl = null)
    {
        _author = new DiscordEmbedAuthor { Name = name, Url = url, IconUrl = iconUrl };
        return this;
    }

    public DiscordEmbedBuilder AddField(string name, string value, bool? inline = null)
    {
        _fields ??= [];
        _fields.Add(new DiscordEmbedField { Name = name, Value = value, Inline = inline });
        return this;
    }

    public DiscordEmbed Build()
    {
        return new DiscordEmbed
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