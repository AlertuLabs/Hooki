using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsHeaderBuilder
{
    private string? _name;
    private string? _value;

    public MsTeamsHeaderBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MsTeamsHeaderBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public MsTeamsHeader Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Name is required for Header.");
        }

        if (string.IsNullOrEmpty(_value))
        {
            throw new InvalidOperationException("Value is required for Header.");
        }

        return new MsTeamsHeader
        {
            Name = _name,
            Value = _value
        };
    }
}