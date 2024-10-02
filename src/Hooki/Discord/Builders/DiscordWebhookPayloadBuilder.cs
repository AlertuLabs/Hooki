using Hooki.Discord.Models;

namespace Hooki.Discord.Builders;

public class DiscordWebhookPayloadBuilder
{
    private readonly DiscordWebhookPayload _payload = new();
    
    public DiscordWebhookPayload Build() => _payload;
    
    public DiscordWebhookPayloadBuilder WithContent(string content)
    {
        _payload.Content = content;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithUsername(string username)
    {
        _payload.Username = username;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithAvatarUrl(string avatarUrl)
    {
        _payload.AvatarUrl = avatarUrl;
        return this;
    }

    public DiscordWebhookPayloadBuilder WithTts(bool tts)
    {
        _payload.Tts = tts;
        return this;
    }

    public DiscordWebhookPayloadBuilder AddEmbed(Action<EmbedBuilder> embedAction)
    {
        var embedBuilder = new EmbedBuilder();
        embedAction(embedBuilder);
        
        _payload.Embeds ??= [];
        _payload.Embeds.Add(embedBuilder.Build());
        
        return this;
    }

    public DiscordWebhookPayloadBuilder WithAllowedMentions(Action<AllowedMentionBuilder> allowedMentionAction)
    {
        var allowedMentionBuilder = new AllowedMentionBuilder();
        allowedMentionAction(allowedMentionBuilder);
        
        _payload.AllowedMentions = allowedMentionBuilder.Build();
        
        return this;
    }

    public DiscordWebhookPayloadBuilder WithThreadName(string threadName)
    {
        _payload.ThreadName = threadName;
        return this;
    }

    public DiscordWebhookPayloadBuilder AddAppliedTag(string tag)
    {
        _payload.AppliedTags ??= [];
        _payload.AppliedTags.Add(tag);
        
        return this;
    }
}