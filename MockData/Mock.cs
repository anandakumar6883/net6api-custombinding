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
            MeisterpruefungDate = new DateTime(2022, 3, 15),
            MeisterpruefungBei = "B",
            Email = "ananda.kumar@outlook.com",
            Birthday = new DateTime(1988, 1, 1),
            ConcessionWater = 1,
            ConcessionGas = 1,
            ConcessionPower = 0,
            ConcessionDistrictHeating = 1,
            ConcessionValidUntil = new DateTime(2023, 2, 18)
        };
    }
}