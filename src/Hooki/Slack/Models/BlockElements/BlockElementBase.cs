using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.BlockElements;

[JsonDerivedType(typeof(ButtonElement), typeDiscriminator: "button")]
[JsonDerivedType(typeof(CheckboxElement), typeDiscriminator: "checkboxes")]
[JsonDerivedType(typeof(DatePickerElement), typeDiscriminator: "datepicker")]
[JsonDerivedType(typeof(DateTimePickerElement), typeDiscriminator: "datetimepicker")]
[JsonDerivedType(typeof(EmailInputElement), typeDiscriminator: "email_text_input")]
[JsonDerivedType(typeof(FileInputElement), typeDiscriminator: "file_input")]
[JsonDerivedType(typeof(ImageElement), typeDiscriminator: "image")]
[JsonDerivedType(typeof(MultiSelectMenuElement), typeDiscriminator: "multi_static_select")]
[JsonDerivedType(typeof(NumberInputElement), typeDiscriminator: "number_input")]
[JsonDerivedType(typeof(OverflowMenuElement), typeDiscriminator: "overflow")]
[JsonDerivedType(typeof(PlainTextInputElement), typeDiscriminator: "plain_text_input")]
[JsonDerivedType(typeof(RadioButtonGroupElement), typeDiscriminator: "radio_buttons")]
[JsonDerivedType(typeof(RichTextInputElement), typeDiscriminator: "rich_text_input")]
[JsonDerivedType(typeof(SelectMenuElement), typeDiscriminator: "static_select")]
[JsonDerivedType(typeof(TimePickerElement), typeDiscriminator: "timepicker")]
[JsonDerivedType(typeof(UrlInputElement), typeDiscriminator: "url_text_input")]
[JsonDerivedType(typeof(WorkflowButtonElement), typeDiscriminator: "workflow_button")]
public abstract class BlockElementBase
{
    [JsonPropertyName("type")]
    public abstract BlockElementType Type { get; }

    [JsonPropertyName("action_id")]
    public string? ActionId { get; set; }
}