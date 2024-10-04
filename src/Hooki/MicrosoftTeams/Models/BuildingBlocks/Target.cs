using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Models.BuildingBlocks;

public class Target
{
    [JsonPropertyName("os")] public required OperatingSystemTypes OperatingSystem { get; set; } = OperatingSystemTypes.Default;

    [JsonPropertyName("uri")] public required string Uri { get; set; }
}

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum OperatingSystemTypes 
{
    [EnumMember(Value = "default")]
    Default,
    
    [EnumMember(Value = "iOS")]
    Ios,
    
    [EnumMember(Value = "android")]
    Android,
    
    [EnumMember(Value = "windows")]
    Windows
}