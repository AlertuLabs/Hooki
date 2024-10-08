using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.Inputs;

namespace Hooki.MicrosoftTeams.JsonConverters;

public class MsTeamsJsonConverter : JsonConverter<MsTeamsInput>
{
    public override MsTeamsInput Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of object");
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        if (!root.TryGetProperty("@type", out var typeProperty))
        {
            throw new JsonException("Cannot find @type property");
        }

        var type = typeProperty.GetString();
        return type switch
        {
            nameof(MsTeamsInputType.TextInput) => JsonSerializer.Deserialize<MsTeamsTextInput>(root.GetRawText(), options)!,
            nameof(MsTeamsInputType.DateInput) => JsonSerializer.Deserialize<MsTeamsDateInput>(root.GetRawText(), options)!,
            nameof(MsTeamsInputType.MultiChoiceInput) => JsonSerializer.Deserialize<MsTeamsMultiChoiceInput>(root.GetRawText(), options)!,
            _ => throw new JsonException($"Unknown input type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, MsTeamsInput value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Write the discriminator property
        writer.WriteString("@type", value.Type.ToString());

        // Use reflection to get all properties of the concrete type
        var properties = value.GetType().GetProperties();
        foreach (var prop in properties)
        {
            // Skip the Type property as we've already written it
            if (prop.Name == nameof(MsTeamsInput.Type)) continue;

            var propValue = prop.GetValue(value);
            if (propValue != null)
            {
                writer.WritePropertyName(prop.Name);
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }
        }

        writer.WriteEndObject();
    }
}