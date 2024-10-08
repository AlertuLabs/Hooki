using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class SlackInputBlockElementConverter : JsonConverter<IInputBlockElement>
{
    public override IInputBlockElement? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            return default;

        var jsonObject = JsonSerializer.Deserialize<JsonObject>(ref reader, options);
        
        IInputBlockElement? item = jsonObject?["Type"]?.GetValue<string>() switch
        {
            "checkboxes" => jsonObject.Deserialize<SlackCheckboxElement>(options),
            "datepicker" => jsonObject.Deserialize<Models.BlockElements.SlackDatePickerElement>(options),
            "datetimepicker" => jsonObject.Deserialize<SlackDateTimePickerElement>(options),
            "email_text_input" => jsonObject.Deserialize<SlackEmailInputElement>(options),
            "file_input" => jsonObject.Deserialize<SlackFileInputElement>(options),
            "multi_static_select" => jsonObject.Deserialize<SlackMultiSelectMenuElement>(options),
            "number_input" => jsonObject.Deserialize<SlackNumberInputElement>(options),
            "plain_text_input" => jsonObject.Deserialize<SlackPlainTextInputElement>(options),
            "radio_buttons" => jsonObject.Deserialize<SlackRadioButtonGroupElement>(options),
            "rich_text_input" => jsonObject.Deserialize<SlackRichTextInputElement>(options),
            "static_select" => jsonObject.Deserialize<SlackSelectMenuElement>(options),
            "timepicker" => jsonObject.Deserialize<SlackTimePickerElement>(options),
            "url_text_input" => jsonObject.Deserialize<SlackUrlInputElement>(options),
            _ => null
        };

        return item;
    }
    
    public override void Write(Utf8JsonWriter writer, IInputBlockElement value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case SlackCheckboxElement checkbox:
                JsonSerializer.Serialize(writer, checkbox, options);
                break;
            case Models.BlockElements.SlackDatePickerElement datePicker:
                JsonSerializer.Serialize(writer, datePicker, options);
                break;
            case SlackDateTimePickerElement dateTimePicker:
                JsonSerializer.Serialize(writer, dateTimePicker, options);
                break;
            case SlackEmailInputElement emailInput:
                JsonSerializer.Serialize(writer, emailInput, options);
                break;
            case SlackFileInputElement fileInput:
                JsonSerializer.Serialize(writer, fileInput, options);
                break;
            case SlackMultiSelectMenuElement multiSelectMenu:
                JsonSerializer.Serialize(writer, multiSelectMenu, options);
                break;
            case SlackNumberInputElement numberInput:
                JsonSerializer.Serialize(writer, numberInput, options);
                break;
            case SlackPlainTextInputElement plainText:
                JsonSerializer.Serialize(writer, plainText, options);
                break;
            case SlackRadioButtonGroupElement radioButton:
                JsonSerializer.Serialize(writer, radioButton, options);
                break;
            case SlackRichTextInputElement richText:
                JsonSerializer.Serialize(writer, richText, options);
                break;
            case SlackSelectMenuElement selectMenu:
                JsonSerializer.Serialize(writer, selectMenu, options);
                break;
            case SlackTimePickerElement timePicker:
                JsonSerializer.Serialize(writer, timePicker, options);
                break;
            case SlackUrlInputElement urlInput:
                JsonSerializer.Serialize(writer, urlInput, options);
                break;
            default:
                throw new JsonException($"Invalid action block element type: {value.GetType()}");
        }
    }
}