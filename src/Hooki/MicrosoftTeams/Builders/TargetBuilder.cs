using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class TargetBuilder
{
    private OperatingSystemTypes _operatingSystem;
    private string? _uri;

    public TargetBuilder WithOperatingSystem(OperatingSystemTypes operatingSystem)
    {
        _operatingSystem = operatingSystem;
        return this;
    }

    public TargetBuilder WithUri(string uri)
    {
        _uri = uri;
        return this;
    }

    public Target Build()
    {
        if (string.IsNullOrEmpty(_uri))
        {
            throw new InvalidOperationException("Uri is required for Target.");
        }

        return new Target
        {
            OperatingSystem = _operatingSystem,
            Uri = _uri
        };
    }
}