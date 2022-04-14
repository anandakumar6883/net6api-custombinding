using Microsoft.AspNetCore.Mvc;

namespace Net6.CustomBinding;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{

    [HttpGet]
    public IEnumerable<Company> GetCompanies()
    {
        return new List<Company>() {
            new Company() { Id=1, Name="Trivium", City="Bangalore", CountryCode="IN", CountryName="India", EMail="support@trivium.com" },
            new Company() { Id=2, Name="Caterpillar", City="Mannheim", CountryCode="DE", CountryName="Germany", EMail="cat-support@caterpillar.de" },
            };
    }

    [HttpPost]
    public Company CreateCompany(Company company)
    {
        // your logic to create the company.

        // created company, with Id.
        company.Id = new Random(23).Next();
        return company;
    }

}