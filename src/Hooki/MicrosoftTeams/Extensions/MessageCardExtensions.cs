using Hooki.MicrosoftTeams.Builders;
using Hooki.MicrosoftTeams.Models;

namespace Hooki.MicrosoftTeams.Extensions;

public static class MessageCardExtensions
{
    public static MessageCard BuildDMessageCard(this Action<MessageCardBuilder> builderAction)
    {
        var builder = new MessageCardBuilder();
        builderAction(builder);
        return builder.Build();
    }
}