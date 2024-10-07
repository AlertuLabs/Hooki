using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class InputBlockElementConverter : JsonConverter<IInputBlockElement>
{
    public override IInputBlockElement? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            return default;

        var jsonObject = JsonSerializer.Deserialize<JsonObject>(ref reader, options);
        
        IInputBlockElement? item = jsonObject?["Type"]?.GetValue<string>() switch
        {
            "checkboxes" => jsonObject.Deserialize<CheckboxElement>(options),
            "datepicker" => jsonObject.Deserialize<DatePickerElement>(options),
            "datetimepicker" => jsonObject.Deserialize<DateTimePickerElement>(options),
            "email_text_input" => jsonObject.Deserialize<EmailInputElement>(options),
            "file_input" => jsonObject.Deserialize<FileInputElement>(options),
            "multi_static_select" => jsonObject.Deserialize<MultiSelectMenuElement>(options),
            "number_input" => jsonObject.Deserialize<NumberInputElement>(options),
            "plain_text_input" => jsonObject.Deserialize<PlainTextInputElement>(options),
            "radio_buttons" => jsonObject.Deserialize<RadioButtonGroupElement>(options),
            "rich_text_input" => jsonObject.Deserialize<RichTextInputElement>(options),
            "static_select" => jsonObject.Deserialize<SelectMenuElement>(options),
            "timepicker" => jsonObject.Deserialize<TimePickerElement>(options),
            "url_text_input" => jsonObject.Deserialize<UrlInputElement>(options),
            _ => null
        };

        return item;
    }
    
    public override void Write(Utf8JsonWriter writer, IInputBlockElement value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case CheckboxElement checkbox:
                JsonSerializer.Serialize(writer, checkbox, options);
                break;
            case DatePickerElement datePicker:
                JsonSerializer.Serialize(writer, datePicker, options);
                break;
            case DateTimePickerElement dateTimePicker:
                JsonSerializer.Serialize(writer, dateTimePicker, options);
                break;
            case EmailInputElement emailInput:
                JsonSerializer.Serialize(writer, emailInput, options);
                break;
            case FileInputElement fileInput:
                JsonSerializer.Serialize(writer, fileInput, options);
                break;
            case MultiSelectMenuElement multiSelectMenu:
                JsonSerializer.Serialize(writer, multiSelectMenu, options);
                break;
            case NumberInputElement numberInput:
                JsonSerializer.Serialize(writer, numberInput, options);
                break;
            case PlainTextInputElement plainText:
                JsonSerializer.Serialize(writer, plainText, options);
                break;
            case RadioButtonGroupElement radioButton:
                JsonSerializer.Serialize(writer, radioButton, options);
                break;
            case RichTextInputElement richText:
                JsonSerializer.Serialize(writer, richText, options);
                break;
            case SelectMenuElement selectMenu:
                JsonSerializer.Serialize(writer, selectMenu, options);
                break;
            case TimePickerElement timePicker:
                JsonSerializer.Serialize(writer, timePicker, options);
                break;
            case UrlInputElement urlInput:
                JsonSerializer.Serialize(writer, urlInput, options);
                break;
            default:
                throw new JsonException($"Invalid action block element type: {value.GetType()}");
        }
    }
}