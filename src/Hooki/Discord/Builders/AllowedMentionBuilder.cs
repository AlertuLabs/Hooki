using Hooki.Discord.Enums;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class AllowedMentionBuilder
{
    private List<AllowedMentionTypes>? _parse;
    private List<string>? _roles;
    private List<string>? _users;
    private bool? _repliedUser;

    public AllowedMentionBuilder AddParse(AllowedMentionTypes type)
    {
        _parse ??= [];
        _parse.Add(type);
        return this;
    }

    public AllowedMentionBuilder AddRole(string roleId)
    {
        _roles ??= [];
        _roles.Add(roleId);
        return this;
    }

    public AllowedMentionBuilder AddUser(string userId)
    {
        _users ??= [];
        _users.Add(userId);
        return this;
    }

    public AllowedMentionBuilder WithRepliedUser(bool repliedUser)
    {
        _repliedUser = repliedUser;
        return this;
    }

    public AllowedMention Build()
    {
        return new AllowedMention
        {
            Parse = _parse,
            Roles = _roles,
            Users = _users,
            RepliedUser = _repliedUser
        };
    }
}