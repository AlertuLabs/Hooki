using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.BuildingBlocks;

namespace Hooki.MicrosoftTeams.Builders;

public class MsTeamsTargetBuilder
{
    private MsTeamsOperatingSystemType _msTeamsOperatingSystem;
    private string? _uri;

    public MsTeamsTargetBuilder WithOperatingSystem(MsTeamsOperatingSystemType msTeamsOperatingSystem)
    {
        _msTeamsOperatingSystem = msTeamsOperatingSystem;
        return this;
    }

    public MsTeamsTargetBuilder WithUri(string uri)
    {
        _uri = uri;
        return this;
    }

    public MsTeamsTarget Build()
    {
        if (string.IsNullOrEmpty(_uri))
        {
            throw new InvalidOperationException("Uri is required for Target.");
        }

        return new MsTeamsTarget
        {
            MsTeamsOperatingSystem = _msTeamsOperatingSystem,
            Uri = _uri
        };
    }
}