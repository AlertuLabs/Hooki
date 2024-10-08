using Hooki.Discord.Enums;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class DiscordAllowedMentionBuilder
{
    private List<DiscordAllowedMentionType>? _parse;
    private List<string>? _roles;
    private List<string>? _users;
    private bool? _repliedUser;

    public DiscordAllowedMentionBuilder AddParse(DiscordAllowedMentionType type)
    {
        _parse ??= [];
        _parse.Add(type);
        return this;
    }

    public DiscordAllowedMentionBuilder AddRole(string roleId)
    {
        _roles ??= [];
        _roles.Add(roleId);
        return this;
    }

    public DiscordAllowedMentionBuilder AddUser(string userId)
    {
        _users ??= [];
        _users.Add(userId);
        return this;
    }

    public DiscordAllowedMentionBuilder WithRepliedUser(bool repliedUser)
    {
        _repliedUser = repliedUser;
        return this;
    }

    public DiscordAllowedMention Build()
    {
        return new DiscordAllowedMention
        {
            Parse = _parse,
            Roles = _roles,
            Users = _users,
            RepliedUser = _repliedUser
        };
    }
}