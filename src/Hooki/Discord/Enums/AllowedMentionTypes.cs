using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.Discord.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AllowedMentionTypes
{
    [EnumMember(Value = "roles")]
    Roles,
    
    [EnumMember(Value = "users")]
    Users,
    
    [EnumMember(Value = "everyone")]
    Everyone
}