using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsFactBuilder
{
    private string? _name;
    private string? _value;

    public MsTeamsFactBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MsTeamsFactBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public MsTeamsFact Build()
    {
        return new MsTeamsFact
        {
            Name = _name ?? throw new InvalidOperationException("Name is required"),
            Value = _value ?? throw new InvalidOperationException("Value is required")
        };
    }
}