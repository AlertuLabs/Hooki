using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class ActionBlockConverter : JsonConverter<BlockBase>
{
    private static readonly Dictionary<string, Type> TypeMap = new()
    {
        { "actions", typeof(ActionBlock) },
        { "context", typeof(ContextBlock) },
        { "divider", typeof(DividerBlock) },
        { "file", typeof(FileBlock) },
        { "header", typeof(HeaderBlock) },
        { "image", typeof(ImageBlock) },
        { "input", typeof(InputBlock) },
        { "rich_text", typeof(RichTextBlock) },
        { "section", typeof(SectionBlock) },
        { "video", typeof(VideoBlock) }
    };

    private static readonly Dictionary<string, Type> ElementTypeMap = new()
    {
        { "button", typeof(ButtonElement) },
        { "checkboxes", typeof(CheckboxElement) },
        { "datepicker", typeof(DatePickerElement) },
        { "datetimepicker", typeof(DateTimePickerElement) },
        { "multi_static_select", typeof(MultiSelectMenuElement) },
        { "overflow", typeof(OverflowMenuElement) },
        { "radio_buttons", typeof(RadioButtonGroupElement) },
        { "rich_text_input", typeof(RichTextInputElement) },
        { "static_select", typeof(SelectMenuElement) },
        { "timepicker", typeof(TimePickerElement) },
        { "workflow_button", typeof(WorkflowButtonElement) }
    };

    public override BlockBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("JSON object expected.");
        }

        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("Missing 'type' property");
        }

        var typeString = typeProperty.GetString()?.ToLower();
        if (!TypeMap.TryGetValue(typeString, out var blockType))
        {
            throw new JsonException($"Unknown block type: {typeString}");
        }

        var block = (BlockBase)Activator.CreateInstance(blockType);

        foreach (var property in blockType.GetProperties())
        {
            var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name.ToLower();
            if (root.TryGetProperty(jsonPropertyName, out var element))
            {
                if (property.Name == "Elements" && blockType == typeof(ActionBlock))
                {
                    var elements = DeserializeActionBlockElements(element, options);
                    property.SetValue(block, elements);
                }
                else
                {
                    var value = JsonSerializer.Deserialize(element.GetRawText(), property.PropertyType, options);
                    property.SetValue(block, value);
                }
            }
        }

        return block;
    }

    public override void Write(Utf8JsonWriter writer, BlockBase value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var property in value.GetType().GetProperties())
        {
            var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name.ToLower();
            var propertyValue = property.GetValue(value);

            if (propertyValue == null) continue;

            writer.WritePropertyName(jsonPropertyName);

            if (property.Name == "Elements" && value is ActionBlock)
            {
                SerializeActionBlockElements(writer, (List<IActionBlockElement>)propertyValue, options);
            }
            else
            {
                JsonSerializer.Serialize(writer, propertyValue, property.PropertyType, options);
            }
        }

        writer.WriteEndObject();
    }

    private List<IActionBlockElement> DeserializeActionBlockElements(JsonElement elementsProperty, JsonSerializerOptions options)
    {
        var elements = new List<IActionBlockElement>();

        foreach (var element in elementsProperty.EnumerateArray())
        {
            if (element.TryGetProperty("type", out var typeProperty))
            {
                var elementTypeString = typeProperty.GetString();
                if (ElementTypeMap.TryGetValue(elementTypeString, out var elementType))
                {
                    var blockElement = (IActionBlockElement)JsonSerializer.Deserialize(element.GetRawText(), elementType, options);
                    elements.Add(blockElement);
                }
                else
                {
                    throw new JsonException($"Unknown element type: {elementTypeString}");
                }
            }
        }

        if (elements.Count == 0)
        {
            throw new JsonException("ActionBlock must contain at least one element");
        }

        return elements;
    }

    private void SerializeActionBlockElements(Utf8JsonWriter writer, List<IActionBlockElement> elements, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var element in elements)
        {
            JsonSerializer.Serialize(writer, element, element.GetType(), options);
        }

        writer.WriteEndArray();
    }
}