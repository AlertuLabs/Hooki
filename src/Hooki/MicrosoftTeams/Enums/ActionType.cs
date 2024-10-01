using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ActionType
{
    [EnumMember(Value = "OpenUri")]
    OpenUri,

    [EnumMember(Value = "HttpPOST")]
    HttpPost,

    [EnumMember(Value = "ActionCard")]
    ActionCard,

    [EnumMember(Value = "InvokeAddInCommand")]
    InvokeAddInCommand
}