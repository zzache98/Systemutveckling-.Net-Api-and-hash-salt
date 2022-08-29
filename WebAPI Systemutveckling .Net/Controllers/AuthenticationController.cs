using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Systemutveckling_.Net.Models;
using WebAPI_Systemutveckling_.Net.Repositories;
using static WebAPI_Systemutveckling_.Net.Repositories.AccountRepository;

namespace WebAPI_Systemutveckling_.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AuthenticationController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult("All required fields must be supplied and valid");

            return await _accountManager.SignUpAsync(model);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignIn model)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult("All required fields must be supplied and valid");

            return await _accountManager.SignInAsync(model);
        }
    }
}
