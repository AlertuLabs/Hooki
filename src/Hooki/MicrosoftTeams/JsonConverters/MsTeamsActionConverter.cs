using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hooki.MicrosoftTeams.Enums;
using Hooki.MicrosoftTeams.Models.Actions;

namespace Hooki.MicrosoftTeams.JsonConverters;

public class MsTeamsActionConverter : JsonConverter<MsTeamsAction>
{
    public override MsTeamsAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for this converter.");
    }

    public override void Write(Utf8JsonWriter writer, MsTeamsAction value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Write the "type" property as a string
        writer.WriteString("@type", GetActionTypeJsonValue(value.Type));

        // Serialize other properties
        foreach (var property in value.GetType().GetProperties())
        {
            if (property.Name == nameof(MsTeamsAction.Type)) continue;

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
    
    private static string GetActionTypeJsonValue(MsTeamsActionType msTeamsActionType)
    {
        return msTeamsActionType switch
        {
            MsTeamsActionType.ActionCard => "ActionCard",
            MsTeamsActionType.HttpPost => "HttpPOST",
            MsTeamsActionType.OpenUri => "OpenUri",
            MsTeamsActionType.InvokeAddInCommand => "InvokeAddInCommand",
            _ => throw new ArgumentOutOfRangeException(nameof(msTeamsActionType), msTeamsActionType, null)
        };
    }
}