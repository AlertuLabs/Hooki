using System.Text.RegularExpressions;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public partial class DiscordAttachmentBuilder
{
    private string? _id;
    private string? _fileName;
    private string? _title;
    private string? _description;
    private string? _contentType;
    private int? _size;
    private string? _url;
    private string? _proxyUrl;
    private int? _height;
    private int? _width;
    private bool? _ephemeral;
    private float? _durationSecs;
    private string? _waveform;
    private int? _flags;
    private byte[]? _content;
    
    [GeneratedRegex(@"^[\w-\.]+$")]
    private static partial Regex MyRegex();

    public DiscordAttachmentBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public DiscordAttachmentBuilder WithFileName(string fileName)
    {
        if (!MyRegex().IsMatch(fileName))
            throw new ArgumentException("FileName must be ASCII alphanumeric with underscores, dashes, or dots.");
        _fileName = fileName;
        return this;
    }

    public DiscordAttachmentBuilder WithTitle(string? title)
    {
        _title = title;
        return this;
    }

    public DiscordAttachmentBuilder WithDescription(string? description)
    {
        _description = description;
        return this;
    }

    public DiscordAttachmentBuilder WithContentType(string? contentType)
    {
        _contentType = contentType;
        return this;
    }

    public DiscordAttachmentBuilder WithSize(int? size)
    {
        _size = size;
        return this;
    }

    public DiscordAttachmentBuilder WithUrl(string? url)
    {
        _url = url;
        return this;
    }

    public DiscordAttachmentBuilder WithProxyUrl(string? proxyUrl)
    {
        _proxyUrl = proxyUrl;
        return this;
    }

    public DiscordAttachmentBuilder WithHeight(int? height)
    {
        _height = height;
        return this;
    }

    public DiscordAttachmentBuilder WithWidth(int? width)
    {
        _width = width;
        return this;
    }

    public DiscordAttachmentBuilder WithEphemeral(bool? ephemeral)
    {
        _ephemeral = ephemeral;
        return this;
    }

    public DiscordAttachmentBuilder WithDurationSecs(float? durationSecs)
    {
        _durationSecs = durationSecs;
        return this;
    }

    public DiscordAttachmentBuilder WithWaveform(string? waveform)
    {
        _waveform = waveform;
        return this;
    }

    public DiscordAttachmentBuilder WithFlags(int? flags)
    {
        _flags = flags;
        return this;
    }

    public DiscordAttachmentBuilder WithContent(byte[]? content)
    {
        _content = content;
        return this;
    }

    public DiscordAttachment Build()
    {
        if (string.IsNullOrWhiteSpace(_id))
            throw new InvalidOperationException("Id is required for Attachment.");
        if (string.IsNullOrWhiteSpace(_fileName))
            throw new InvalidOperationException("FileName is required for Attachment.");

        return new DiscordAttachment
        {
            Id = _id,
            FileName = _fileName,
            Title = _title,
            Description = _description,
            ContentType = _contentType,
            Size = _size,
            Url = _url,
            ProxyUrl = _proxyUrl,
            Height = _height,
            Width = _width,
            Ephemeral = _ephemeral,
            DurationSecs = _durationSecs,
            Waveform = _waveform,
            Flags = _flags,
            Content = _content
        };
    }
}