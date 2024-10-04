using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class FactBuilder
{
    private string? _name;
    private string? _value;

    public FactBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public FactBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public Fact Build()
    {
        return new Fact
        {
            Name = _name ?? throw new InvalidOperationException("Name is required"),
            Value = _value ?? throw new InvalidOperationException("Value is required")
        };
    }
}