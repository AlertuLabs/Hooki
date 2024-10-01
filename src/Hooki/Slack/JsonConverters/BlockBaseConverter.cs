using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.JsonConverters;

public class BlockBaseConverter : JsonConverter<BlockBase>
{
    public override BlockBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for this converter.");
    }

    public override void Write(Utf8JsonWriter writer, BlockBase value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Write the "type" property as a string
        writer.WriteString("type", GetBlockTypeJsonValue(value.Type));

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
    
    private static string GetBlockTypeJsonValue(BlockType blockType)
    {
        return blockType switch
        {
            BlockType.ActionBlock => "actions",
            BlockType.ContextBlock => "context",
            BlockType.DividerBlock => "divider",
            BlockType.FileBlock => "file",
            BlockType.HeaderBlock => "header",
            BlockType.ImageBlock => "image",
            BlockType.InputBlock => "input",
            BlockType.RichTextBlock => "rich_text",
            BlockType.SectionBlock => "section",
            BlockType.VideoBlock => "video",
            _ => throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null)
        };
    }
}