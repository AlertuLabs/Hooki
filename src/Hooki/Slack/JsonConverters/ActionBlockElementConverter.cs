using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class ActionBlockElementConverter : JsonConverter<List<IActionBlockElement>>
{
    public override List<IActionBlockElement>? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            return default;

        List<IActionBlockElement> actionBlocks = default!;

        foreach (var jsonObject in JsonSerializer.Deserialize<List<JsonObject>>(ref reader, options)!)
        {
            IActionBlockElement? item = jsonObject["Type"]?.GetValue<string>() switch
            {
                "button" => jsonObject.Deserialize<ButtonElement>(options),
                "checkboxes" => jsonObject.Deserialize<CheckboxElement>(options),
                "datepicker" => jsonObject.Deserialize<DatePickerElement>(options),
                "datetimepicker" => jsonObject.Deserialize<DateTimePickerElement>(options),
                "multi_static_select" => jsonObject.Deserialize<MultiSelectMenuElement>(options),
                "overflow" => jsonObject.Deserialize<OverflowMenuElement>(options),
                "radio_buttons" => jsonObject.Deserialize<RadioButtonGroupElement>(options),
                "rich_text_input" => jsonObject.Deserialize<RichTextInputElement>(options),
                "static_select" => jsonObject.Deserialize<SelectMenuElement>(options),
                "timepicker" => jsonObject.Deserialize<TimePickerElement>(options),
                "workflow_button" => jsonObject.Deserialize<WorkflowButtonElement>(options),
                _ => null
            };

            if (item is null) continue;

            actionBlocks ??= new();
            actionBlocks.Add(item);
        }

        return actionBlocks;
    }

    public override void Write(Utf8JsonWriter writer, List<IActionBlockElement> values, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var value in values)
        {
            switch (value)
            {
                case ButtonElement button:
                    JsonSerializer.Serialize(writer, button, options);
                    break;
                case CheckboxElement checkbox:
                    JsonSerializer.Serialize(writer, checkbox, options);
                    break;
                case DatePickerElement datePicker:
                    JsonSerializer.Serialize(writer, datePicker, options);
                    break;
                case DateTimePickerElement dateTimePicker:
                    JsonSerializer.Serialize(writer, dateTimePicker, options);
                    break;
                case MultiSelectMenuElement multiSelect:
                    JsonSerializer.Serialize(writer, multiSelect, options);
                    break;
                case OverflowMenuElement overflow:
                    JsonSerializer.Serialize(writer, overflow, options);
                    break;
                case RadioButtonGroupElement radioButton:
                    JsonSerializer.Serialize(writer, radioButton, options);
                    break;
                case RichTextInputElement richTextInput:
                    JsonSerializer.Serialize(writer, richTextInput, options);
                    break;
                case SelectMenuElement select:
                    JsonSerializer.Serialize(writer, select, options);
                    break;
                case TimePickerElement timePicker:
                    JsonSerializer.Serialize(writer, timePicker, options);
                    break;
                case WorkflowButtonElement workflowButton:
                    JsonSerializer.Serialize(writer, workflowButton, options);
                    break;
                default:
                    throw new JsonException($"Invalid action block element type: {value.GetType()}");
            }
        }
        writer.WriteEndArray();
    }
}