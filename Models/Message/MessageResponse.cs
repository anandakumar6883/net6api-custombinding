using System.Text.Json.Serialization;

namespace Net6.CustomBinding;

public class MessageResponse
{
    [JsonPropertyName("message")]
    public IEnumerable<MessageEntry>? Messages { get; set; }
   
}

public class MessageCountResponse
{
    public int Count { get; set; }
}