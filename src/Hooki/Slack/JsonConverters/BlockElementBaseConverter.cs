using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class BlockElementBaseConverter : JsonConverter<BlockElementBase>
{
    public override BlockElementBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for this converter.");
    }

    public override void Write(Utf8JsonWriter writer, BlockElementBase value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Write the "type" property as a string
        writer.WriteString("type", GetBlockElementTypeJsonValue(value.Type));

        // Serialize other properties
        foreach (var property in value.GetType().GetProperties())
        {
            if (property.Name == nameof(BlockBase.Type)) continue;

            var propertyValue = property.GetValue(value);
            
            if (propertyValue == null) continue;
            
            var propertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name 
                               ?? options.PropertyNamingPolicy?.ConvertName(property.Name) 
                               ?? property.Name;
            
            writer.WritePropertyName(propertyName);
            JsonSerializer.Serialize(writer, propertyValue, property.PropertyType, options);
        }

        writer.WriteEndObject();
    }
    
    private static string GetBlockElementTypeJsonValue(BlockElementType blockElementType)
    {
        return blockElementType switch
        {
            BlockElementType.Button => nameof(BlockElementType.Button).ToLower(),
            BlockElementType.Checkboxes => nameof(BlockElementType.Checkboxes).ToLower(),
            BlockElementType.DatePicker => nameof(BlockElementType.DatePicker).ToLower(),
            BlockElementType.DatetimePicker => nameof(BlockElementType.DatetimePicker).ToLower(),
            BlockElementType.EmailInput => "email_text_input",
            BlockElementType.FileInput => "file_input",
            BlockElementType.Image => nameof(BlockElementType.Image).ToLower(),
            BlockElementType.MultiSelectMenu => "multi_static_select",
            BlockElementType.NumberInput => "number_input",
            BlockElementType.PlainTextInput => "plain_text_input",
            BlockElementType.RadioButtonGroup => "radio_buttons",
            BlockElementType.RichTextInput => "rich_text_input",
            BlockElementType.SelectMenu => "static_select",
            BlockElementType.TimePicker => "timepicker",
            BlockElementType.UrlInput => "url_text_input",
            BlockElementType.WorkflowButton => "workflow_button",
            BlockElementType.OverflowMenu => "overflow",
            _ => throw new ArgumentOutOfRangeException(nameof(blockElementType), blockElementType, null)
        };
    }
}