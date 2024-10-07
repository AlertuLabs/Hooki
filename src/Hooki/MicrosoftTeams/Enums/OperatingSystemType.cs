using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum OperatingSystemType
{
    [EnumMember(Value = "default")]
    Default,
    
    [EnumMember(Value = "iOS")]
    IOS,
    
    [EnumMember(Value = "android")]
    Android,
    
    [EnumMember(Value = "windows")]
    Windows
}