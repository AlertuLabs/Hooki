using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class DiscordWebhookPayloadBuilder
{
    private string? _content;
    private string? _username;
    private string? _avatarUrl;
    private bool? _tts;
    private List<Embed>? _embeds;
    private AllowedMention? _allowedMentions;
    private List<object>? _components;
    private List<FileContent>? _files;
    private string? _payloadJson;
    private List<Attachment>? _attachments;
    private int? _flags;
    private string? _threadName;
    private List<string>? _appliedTags;
    private PollCreateRequest? _poll;

    public DiscordWebhookPayloadBuilder WithContent(string content)
    {
        _content = content;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithUsername(string username)
    {
        _username = username;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithAvatarUrl(string avatarUrl)
    {
        _avatarUrl = avatarUrl;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithTts(bool tts)
    {
        _tts = tts;
        return this;
    }

    public DiscordWebhookPayloadBuilder AddEmbed(Action<EmbedBuilder> embedAction)
    {
        var embedBuilder = new EmbedBuilder();
        embedAction(embedBuilder);
        _embeds ??= new List<Embed>();
        _embeds.Add(embedBuilder.Build());
        return this;
    }

    public DiscordWebhookPayloadBuilder WithAllowedMentions(Action<AllowedMentionBuilder> allowedMentionAction)
    {
        var allowedMentionBuilder = new AllowedMentionBuilder();
        allowedMentionAction(allowedMentionBuilder);
        _allowedMentions = allowedMentionBuilder.Build();
        return this;
    }

    public DiscordWebhookPayloadBuilder AddComponent(object component)
    {
        _components ??= new List<object>();
        _components.Add(component);
        return this;
    }

    public DiscordWebhookPayloadBuilder AddFile(FileContent file)
    {
        _files ??= new List<FileContent>();
        _files.Add(file);
        return this;
    }

    public DiscordWebhookPayloadBuilder WithPayloadJson(string payloadJson)
    {
        _payloadJson = payloadJson;
        return this;
    }

    public DiscordWebhookPayloadBuilder AddAttachment(Attachment attachment)
    {
        _attachments ??= new List<Attachment>();
        _attachments.Add(attachment);
        return this;
    }

    public DiscordWebhookPayloadBuilder WithFlags(int flags)
    {
        _flags = flags;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithThreadName(string threadName)
    {
        _threadName = threadName;
        return this;
    }

    public DiscordWebhookPayloadBuilder AddAppliedTag(string tag)
    {
        _appliedTags ??= new List<string>();
        _appliedTags.Add(tag);
        return this;
    }

    public DiscordWebhookPayloadBuilder WithPoll(Action<PollCreateRequestBuilder> pollAction)
    {
        var pollCreateRequestBuilder = new PollCreateRequestBuilder();
        pollAction(pollCreateRequestBuilder);

        _poll = pollCreateRequestBuilder.Build();
        return this;
    }

    public DiscordWebhookPayload Build()
    {
        return new DiscordWebhookPayload
        {
            Content = _content,
            Username = _username,
            AvatarUrl = _avatarUrl,
            Tts = _tts,
            Embeds = _embeds,
            AllowedMentions = _allowedMentions,
            Components = _components,
            Files = _files,
            PayloadJson = _payloadJson,
            Attachments = _attachments,
            Flags = _flags,
            ThreadName = _threadName,
            AppliedTags = _appliedTags,
            Poll = _poll
        };
    }
}