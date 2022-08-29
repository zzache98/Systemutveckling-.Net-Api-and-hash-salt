using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Systemutveckling_.Net.Helpers;
using WebAPI_Systemutveckling_.Net.Models;
using WebAPI_Systemutveckling_.Net.Repositories;
using static WebAPI_Systemutveckling_.Net.Repositories.AccountRepository;

namespace WebAPI_Systemutveckling_.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _accountManager.GetAccountsAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var result = await _accountManager.GetAccountAsync(id);
            if (result != null)
                return new OkObjectResult(result);

            return new NotFoundObjectResult($"a user account with id {id} was not found");
        }

        [HttpPut("{id}")]
        [UseApiKey]
        public async Task<IActionResult> UpdateOne(Guid id, Account account)
        {
            var result = await _accountManager.UpdateAccountAsync(id, account);
            if (result != null)
                return new OkObjectResult(result);

            return new NotFoundObjectResult($"unable to update user account with id {id}");
        }

        [HttpDelete("{id}")]
        [UseApiKey]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            if (await _accountManager.DeleteAccountAsync(id))
                return new NoContentResult();

            return new BadRequestObjectResult($"unable to delete user account with id {id}");
        }
    }
}
