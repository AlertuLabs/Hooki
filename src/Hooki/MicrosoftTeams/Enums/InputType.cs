using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.MicrosoftTeams.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InputType
{
    [EnumMember(Value = "TextInput")]
    TextInput,
    
    [EnumMember(Value = "DateInput")]
    DateInput,
    
    [EnumMember(Value = "MultichoiceInput")]
    MultiChoiceInput
}