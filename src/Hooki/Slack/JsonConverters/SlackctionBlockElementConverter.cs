using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class SlackctionBlockElementConverter : JsonConverter<List<ISlackActionBlockElement>>
{
    public override List<ISlackActionBlockElement>? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            return default;

        List<ISlackActionBlockElement> actionBlocks = default!;

        foreach (var jsonObject in JsonSerializer.Deserialize<List<JsonObject>>(ref reader, options)!)
        {
            ISlackActionBlockElement? item = jsonObject["Type"]?.GetValue<string>() switch
            {
                "button" => jsonObject.Deserialize<SlackButtonElement>(options),
                "checkboxes" => jsonObject.Deserialize<SlackCheckboxElement>(options),
                "datepicker" => jsonObject.Deserialize<Models.BlockElements.SlackDatePickerElement>(options),
                "datetimepicker" => jsonObject.Deserialize<SlackDateTimePickerElement>(options),
                "multi_static_select" => jsonObject.Deserialize<SlackMultiSelectMenuElement>(options),
                "overflow" => jsonObject.Deserialize<SlackOverflowMenuElement>(options),
                "radio_buttons" => jsonObject.Deserialize<SlackRadioButtonGroupElement>(options),
                "rich_text_input" => jsonObject.Deserialize<SlackRichTextInputElement>(options),
                "static_select" => jsonObject.Deserialize<SlackSelectMenuElement>(options),
                "timepicker" => jsonObject.Deserialize<SlackTimePickerElement>(options),
                "workflow_button" => jsonObject.Deserialize<SlackWorkflowButtonElement>(options),
                _ => null
            };

            if (item is null) continue;

            actionBlocks ??= new();
            actionBlocks.Add(item);
        }

        return actionBlocks;
    }

    public override void Write(Utf8JsonWriter writer, List<ISlackActionBlockElement> values, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var value in values)
        {
            switch (value)
            {
                case SlackButtonElement button:
                    JsonSerializer.Serialize(writer, button, options);
                    break;
                case SlackCheckboxElement checkbox:
                    JsonSerializer.Serialize(writer, checkbox, options);
                    break;
                case Models.BlockElements.SlackDatePickerElement datePicker:
                    JsonSerializer.Serialize(writer, datePicker, options);
                    break;
                case SlackDateTimePickerElement dateTimePicker:
                    JsonSerializer.Serialize(writer, dateTimePicker, options);
                    break;
                case SlackMultiSelectMenuElement multiSelect:
                    JsonSerializer.Serialize(writer, multiSelect, options);
                    break;
                case SlackOverflowMenuElement overflow:
                    JsonSerializer.Serialize(writer, overflow, options);
                    break;
                case SlackRadioButtonGroupElement radioButton:
                    JsonSerializer.Serialize(writer, radioButton, options);
                    break;
                case SlackRichTextInputElement richTextInput:
                    JsonSerializer.Serialize(writer, richTextInput, options);
                    break;
                case SlackSelectMenuElement select:
                    JsonSerializer.Serialize(writer, select, options);
                    break;
                case SlackTimePickerElement timePicker:
                    JsonSerializer.Serialize(writer, timePicker, options);
                    break;
                case SlackWorkflowButtonElement workflowButton:
                    JsonSerializer.Serialize(writer, workflowButton, options);
                    break;
                default:
                    throw new JsonException($"Invalid action block element type: {value.GetType()}");
            }
        }
        writer.WriteEndArray();
    }
}