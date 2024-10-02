using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class EmbedBuilder
{
    private readonly Embed _embed = new();

    public EmbedBuilder WithTitle(string title)
    {
        _embed.Title = title;
        return this;
    }

    public EmbedBuilder WithDescription(string description)
    {
        _embed.Description = description;
        return this;
    }

    public EmbedBuilder WithUrl(string url)
    {
        _embed.Url = url;
        return this;
    }

    public EmbedBuilder WithTimestamp(DateTimeOffset timestamp)
    {
        _embed.Timestamp = timestamp;
        return this;
    }

    public EmbedBuilder WithColor(int color)
    {
        _embed.Color = color;
        return this;
    }

    public EmbedBuilder WithFooter(string text, string? iconUrl = null)
    {
        _embed.Footer = new EmbedFooter { Text = text, IconUrl = iconUrl };
        return this;
    }

    public EmbedBuilder WithImage(string url)
    {
        _embed.Image = new EmbedImage { Url = url };
        return this;
    }

    public EmbedBuilder WithThumbnail(string url)
    {
        _embed.Thumbnail = new EmbedThumbnail { Url = url };
        return this;
    }

    public EmbedBuilder WithAuthor(string name, string? url = null, string? iconUrl = null)
    {
        _embed.Author = new EmbedAuthor { Name = name, Url = url, IconUrl = iconUrl };
        return this;
    }

    public EmbedBuilder AddField(string name, string value, bool? inline = null)
    {
        _embed.Fields ??= [];
        _embed.Fields.Add(new EmbedField { Name = name, Value = value, Inline = inline });
        return this;
    }

    public Embed Build() => _embed;
}