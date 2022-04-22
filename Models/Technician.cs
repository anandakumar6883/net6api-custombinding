using System.Text.Json.Serialization;

namespace Net6.CustomBinding.Models;

[JsonNumberHandling(JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString)]
public class Technician
{
    [JsonPropertyName("technician_id")]
    public int TechnicianId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
    public string? Role { get; set; }
    public string? Telephone { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("meisterpruefung_date")]
    public DateOnly MeisterpruefungDate { get; set; }
    [JsonPropertyName("meisterpruefung_bei")]
    public string? MeisterpruefungBei { get; set;}
    public string? Email { get; set; }
    public DateOnly Birthday { get; set; }
     [JsonPropertyName("concession_water")]
    public int ConcessionWater { get; set; }
    [JsonPropertyName("concession_gas")]
    public int ConcessionGas { get; set; }
    [JsonPropertyName("concession_power")]
    public int ConcessionPower { get; set; }
    [JsonPropertyName("concession_district_heating")]
    public int ConcessionDistrictHeating { get; set; }
    [JsonPropertyName("concession_valid_until")]
    public DateOnly ConcessionValidUntil { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<Company>? Company { get; set; }
     
}