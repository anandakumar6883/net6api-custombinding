public class LookupEntry
{
    public int Id { get; set; }

    // power_place_of_meter, power_type_of_facility
    public string? Category { get; set; }
    
    // Housing, Commercial, common_facility, generation_facility
    public string? OptionCode { get; set; }
    
    // Housing, Commercial, Community Facility, Production Facility
    public string? Name { get; set; }
    
    // 1,2,3,4
    public int Order { get; set; }
    
    // en , de
    public string? Locale { get; set; }
    
}