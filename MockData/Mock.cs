using Net6.CustomBinding.Models;

namespace Net6.CustomBinding;

public static class Mock
{
    public static Technician GetTechnician(){

        return new Technician() {
            TechnicianId = 1234,
            Title = "Herr",
            Status = "active",
            Role = "",
            Telephone = "",
            FirstName = "Ananda",
            LastName = "Kumar",
            MeisterpruefungDate = new DateOnly(2022, 1, 15),
            MeisterpruefungBei = "B",
            Email = "ananda.kumar@outlook.com",
            Birthday = new DateOnly(1988, 1, 1),
            ConcessionWater = 1,
            ConcessionGas = 1,
            ConcessionPower = 0,
            ConcessionDistrictHeating = 1,
            ConcessionValidUntil = new DateOnly(2023, 2, 18),
            Company = new List<Company>() { GetCompany(0) }
        };
    }

    public static Company GetCompany(int index)
    {
        return new List<Company>() {
            new Company() { Id=1, Name="Trivium", City="Bangalore", CountryCode="IN", CountryName="India", EMail="support@trivium.com" },
            new Company() { Id=2, Name="Caterpillar", City="Mannheim", CountryCode="DE", CountryName="Germany", EMail="cat-support@caterpillar.de" },
            new Company() { Id=3, Name="B+K", City="Munchen", CountryCode="DE", CountryName="Germany", EMail="support@bk.com" },
            new Company() { Id=4, Name="Microsoft", City="Seattle", CountryCode="US", CountryName="United States", EMail="support@microsoft.com" },
            }[index];
    }


}