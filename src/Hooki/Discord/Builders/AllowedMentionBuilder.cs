using Hooki.Discord.Enums;
using Hooki.Discord.Models.BuildingBlocks;

namespace Hooki.Discord.Builders;

public class AllowedMentionBuilder
{
    private readonly AllowedMention _allowedMention = new();

    public AllowedMentionBuilder AddParse(AllowedMentionTypes type)
    {
        _allowedMention.Parse ??= [];
        _allowedMention.Parse.Add(type);
        return this;
    }

    public AllowedMentionBuilder AddRole(string roleId)
    {
        _allowedMention.Roles ??= [];
        _allowedMention.Roles.Add(roleId);
        return this;
    }

    public AllowedMentionBuilder AddUser(string userId)
    {
        _allowedMention.Users ??= [];
        _allowedMention.Users.Add(userId);
        return this;
    }

    public AllowedMentionBuilder WithRepliedUser(bool repliedUser)
    {
        _allowedMention.RepliedUser = repliedUser;
        return this;
    }

    public AllowedMention Build() => _allowedMention;
}