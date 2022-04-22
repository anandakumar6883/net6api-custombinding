using System.Text.Json;
using System.Text.Json.Serialization;

public class NestedClassJsonConverter<TValue> : JsonConverter<TValue>
{
    private readonly string _propertyName; 
    private readonly string _className;

    private readonly JsonSerializerOptions _referenceOptions;

    public NestedClassJsonConverter(JsonSerializerOptions referenceOptions)
    {
        _className = _propertyName = FormatPropertyName(typeof(TValue).Name, referenceOptions);
         ClassNameAttribute attr = (ClassNameAttribute) Attribute.GetCustomAttribute(typeof(TValue), typeof(ClassNameAttribute));
         if (attr != null)
         {
             _className = attr.Name;
         }
        _referenceOptions = referenceOptions;
    }

    public override TValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = default(TValue);
        var propertyFound = false;

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            return value;
        }

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName when IsPropertyFound(reader.GetString()):
                    propertyFound = true;
                    break;
                case JsonTokenType.StartObject when propertyFound:
                    value = JsonSerializer.Deserialize<TValue>(ref reader, _referenceOptions);
                    propertyFound = false;
                    break;
            }
        }

        return value;
    }

    public override void Write(Utf8JsonWriter writer, TValue? value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(_className);
        writer.WriteStartArray();
        JsonSerializer.Serialize(writer, value, _referenceOptions);
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    private bool IsPropertyFound(string? propertyName)
    {
        return string.Equals(_propertyName, propertyName,
            _referenceOptions.PropertyNameCaseInsensitive
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal);
    }

    private static string FormatPropertyName(string propertyName, JsonSerializerOptions options)
    {
        return options.PropertyNamingPolicy != null
            ? options.PropertyNamingPolicy.ConvertName(propertyName)
            : propertyName;
    }
}