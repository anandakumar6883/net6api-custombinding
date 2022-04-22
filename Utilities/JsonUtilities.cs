using System.Text;
using System.Text.Json;

public static class JsonUtilities
{

    public static JsonSerializerOptions APISerializationOptions() 
    {
        var setup = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = false,
            WriteIndented = true
        };

        setup.Converters.Add(new DateOnlyJsonConverter());

        return setup;
    }  

    public static string JsonSerializeNestedClass<TValue>(TValue? value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, GetConverterOptions<TValue>(options));
    }

    public static async Task<string> JsonSerializeNestedClassAsync<TValue>(TValue? value,
        JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        await using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, value, GetConverterOptions<TValue>(options), cancellationToken);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public static TValue? JsonDeserializeNestedClass<TValue>(string json, JsonSerializerOptions? options)
    {
        return JsonSerializer.Deserialize<TValue>(json, GetConverterOptions<TValue>(options));
    }

    public static async Task<TValue?> JsonDeserializeNestedClassAsync<TValue>(string json,
        JsonSerializerOptions? options, CancellationToken cancellationToken = default)
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        return await JsonSerializer.DeserializeAsync<TValue>(stream, GetConverterOptions<TValue>(options),
            cancellationToken);
    }

    private static JsonSerializerOptions GetConverterOptions<TValue>(JsonSerializerOptions? options = null)
    {
        var referenceOptions = options == null ? new JsonSerializerOptions() : new JsonSerializerOptions(options);
        var converterOptions = new JsonSerializerOptions(referenceOptions);
        converterOptions.Converters.Add(new NestedClassJsonConverter<TValue>(referenceOptions));

        // Add DateOnlyJsonConverter
        //converterOptions.Converters.Add(new DateOnlyJsonConverter());

        return converterOptions;
    }
}