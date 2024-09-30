using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.JsonConverters;

//ToDo: Refactor this in .NET 9 with new attribute: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonStringEnumMemberNameAttribute.cs
public class TextObjectTypesConverter : JsonConverter<TextObjectTypes>
{
    public override TextObjectTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        
        return value switch
        {
            "plain_text" => TextObjectTypes.PlainText,
            "mrkdwn" => TextObjectTypes.Markdown,
            _ => throw new JsonException($"Unable to convert '{value}' to TextObjectTypes")
        };
    }

    public override void Write(Utf8JsonWriter writer, TextObjectTypes value, JsonSerializerOptions options)
    {
        var stringValue = value switch
        {
            TextObjectTypes.PlainText => "plain_text",
            TextObjectTypes.Markdown => "mrkdwn",
            _ => throw new JsonException($"Unable to convert '{value}' to string")
        };
        writer.WriteStringValue(stringValue);
    }
}