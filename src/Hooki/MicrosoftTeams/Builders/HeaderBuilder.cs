using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class HeaderBuilder
{
    private string? _name;
    private string? _value;

    public HeaderBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HeaderBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public Header Build()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Name is required for Header.");
        }

        if (string.IsNullOrEmpty(_value))
        {
            throw new InvalidOperationException("Value is required for Header.");
        }

        return new Header
        {
            Name = _name,
            Value = _value
        };
    }
}