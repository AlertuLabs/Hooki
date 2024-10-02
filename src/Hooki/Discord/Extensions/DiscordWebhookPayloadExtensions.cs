using Hooki.Discord.Builders;
using Hooki.Discord.Models;

namespace Hooki.Discord.Extensions;

public static class DiscordWebhookPayloadExtensions
{
    public static DiscordWebhookPayload BuildDiscordWebhookPayload(this Action<DiscordWebhookPayloadBuilder> builderAction)
    {
        var builder = new DiscordWebhookPayloadBuilder();
        builderAction(builder);
        return builder.Build();
    }
}