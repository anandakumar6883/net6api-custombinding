using System.Text.Json.Serialization;

namespace Net6.CustomBinding;

[JsonNumberHandling(JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString)]
public class MessageEntry
{
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    [JsonPropertyName("message_date")]
    public DateTime MessageDate { get; set; }

    [JsonPropertyName("message_title")]
    public string? MessageTitle { get; set; }

    [JsonPropertyName("message_text")]
    public string? MessageText { get; set; }

    [JsonPropertyName("message_read")]
    public int MessageRead { get; set; }

    [JsonPropertyName("technician_id")]
    public int TechnicianId { get; set; }
}
