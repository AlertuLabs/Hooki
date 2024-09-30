using System.Text.Json.Serialization;

namespace Hooki.Slack.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlockElementType
{
    [JsonPropertyName("button")]
    Button,

    [JsonPropertyName("checkboxes")]
    Checkboxes,

    [JsonPropertyName("datepicker")]
    DatePicker,

    [JsonPropertyName("datetimepicker")]
    DatetimePicker,

    [JsonPropertyName("email_text_input")]
    EmailInput,

    [JsonPropertyName("file_input")]
    FileInput,

    [JsonPropertyName("image")]
    Image,

    [JsonPropertyName("multi_static_select")]
    MultiSelectMenu,

    [JsonPropertyName("number_input")]
    NumberInput,

    [JsonPropertyName("overflow")]
    OverflowMenu,

    [JsonPropertyName("plain_text_input")]
    PlainTextInput,

    [JsonPropertyName("radio_buttons")]
    RadioButtonGroup,

    [JsonPropertyName("rich_text_input")]
    RichTextInput,

    [JsonPropertyName("static_select")]
    SelectMenu,

    [JsonPropertyName("timepicker")]
    TimePicker,

    [JsonPropertyName("url_text_input")]
    UrlInput,

    [JsonPropertyName("workflow_button")]
    WorkflowButton
}