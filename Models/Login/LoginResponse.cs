using System.Text.Json.Serialization;

namespace Net6.CustomBinding.Models;

[ClassName("login")]
public class LoginResponse
{
    [JsonPropertyName("result")]
    public string? Result { get; set; }
    
    [JsonPropertyName("technician_id")]
    public int TechnicianId { get; set; }
    public IEnumerable<Technician>? Technician { get; set; }
        
}