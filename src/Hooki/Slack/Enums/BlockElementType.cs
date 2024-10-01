using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum BlockElementType
{
    [EnumMember(Value = "button")]
    Button,

    [EnumMember(Value = "checkboxes")]
    Checkboxes,

    [EnumMember(Value = "datepicker")]
    DatePicker,

    [EnumMember(Value = "datetimepicker")]
    DatetimePicker,

    [EnumMember(Value = "email_text_input")]
    EmailInput,

    [EnumMember(Value = "file_input")]
    FileInput,

    [EnumMember(Value = "image")]
    Image,

    [EnumMember(Value = "multi_static_select")]
    MultiSelectMenu,

    [EnumMember(Value = "number_input")]
    NumberInput,

    [EnumMember(Value = "overflow")]
    OverflowMenu,

    [EnumMember(Value = "plain_text_input")]
    PlainTextInput,

    [EnumMember(Value = "radio_buttons")]
    RadioButtonGroup,

    [EnumMember(Value = "rich_text_input")]
    RichTextInput,

    [EnumMember(Value = "static_select")]
    SelectMenu,

    [EnumMember(Value = "timepicker")]
    TimePicker,

    [EnumMember(Value = "url_text_input")]
    UrlInput,

    [EnumMember(Value = "workflow_button")]
    WorkflowButton
}