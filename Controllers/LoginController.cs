using Microsoft.AspNetCore.Mvc;
using Net6.CustomBinding.Models;

namespace Net6.CustomBinding;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate(LoginRequest user)
    {

        //* for checking if the model binding works as expected *//
        Console.WriteLine("email: " + user.Email);
        Console.WriteLine("password: " + user.Password);

        //* Your logic to authenticate. *//

        // return authenticated user details.
        var output = new LoginResponse()
        {
            Result = "success",
            TechnicianId = 123,
            Technician = new List<Technician>() { Mock.GetTechnician() }
        };

        //return Ok(output);                                    // without any conversion
        //return Ok(FormatAuthenticateResponse(output));        // using dynamic object preparation
        return Ok(await JsonUtilities.JsonSerializeNestedClassAsync(output, JsonUtilities.APISerializationOptions()));        // using custom JsonConverter
    }

    [HttpGet("dynamic")]
    public IActionResult Get()
    {
        dynamic output = new[] { new
            {
                Result = "success",
                TechnicianId = "123",
                Technician = new[] { Mock.GetTechnician() }
            } };


        dynamic result = new { Login = output };

        return Ok(result);
    }

    #region Helper Method

    private object FormatAuthenticateResponse(LoginResponse data)
    {
        dynamic arrayOfData = new[] { data };
        return new { Login = arrayOfData };
    }

    #endregion

}