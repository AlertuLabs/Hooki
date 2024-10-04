using Hooki.Discord.Models;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class DiscordWebhookPayloadBuilder
{
    private string? _content;
    private string? _username;
    private string? _avatarUrl;
    private bool? _tts;
    private AllowedMention? _allowedMentions;
    private string? _threadName;
    private List<FileContent>? _files;
    private List<Attachment>? _attachments;
    private List<string>? _appliedTags;
    private List<Embed>? _embeds;

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
    
    public DiscordWebhookPayloadBuilder WithAllowedMentions(Action<AllowedMentionBuilder> allowedMentionAction)
    {
        var allowedMentionBuilder = new AllowedMentionBuilder();
        allowedMentionAction(allowedMentionBuilder);
        _allowedMentions = allowedMentionBuilder.Build();
        return this;
    }

    public DiscordWebhookPayloadBuilder WithThreadName(string threadName)
    {
        _threadName = threadName;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithFiles(List<FileContent> files)
    {
        _files ??= [];
        _files.AddRange(files);
        return this;
    }

    public DiscordWebhookPayloadBuilder WithAttachments(List<Attachment> attachments)
    {
        _attachments ??= [];
        _attachments.AddRange(attachments);
        return this;
    }

    public DiscordWebhookPayloadBuilder AddAttachment(Attachment attachment)
    {
        _attachments ??= [];
        _attachments.Add(attachment);
        return this;
    }
    
    public DiscordWebhookPayloadBuilder AddFile(FileContent file)
    {
        _files ??= new List<FileContent>();
        _files.Add(file);
        return this;
    }

    public DiscordWebhookPayloadBuilder AddAppliedTag(string tag)
    {
        _appliedTags ??= [];
        _appliedTags.Add(tag);
        return this;
    }
    
    public DiscordWebhookPayloadBuilder AddEmbed(Action<EmbedBuilder> embedAction)
    {
        var embedBuilder = new EmbedBuilder();
        embedAction(embedBuilder);
        _embeds ??= [];
        _embeds.Add(embedBuilder.Build());
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
            AllowedMentions = _allowedMentions,
            ThreadName = _threadName,
            Files = _files,
            Attachments = _attachments,
            AppliedTags = _appliedTags,
            Embeds = _embeds
        };
    }
}