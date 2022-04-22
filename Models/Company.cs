using System.Text.Json.Serialization;

namespace Net6.CustomBinding.Models;

[JsonNumberHandling(JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString)]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? CountryCode { get; set; }
    public string? CountryName { get; set; }
    public string? EMail { get; set; }
    
}