using JobWebsiteAPI.Models.AccountModels;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace JobWebsiteAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register/personal")]
        public async Task<ActionResult> RegisterPersonal([FromBody] RegisterPersonalAccountDto dto)
        {
            await _accountService.RegisterPersonalAccount(dto);
            return Ok();
        }
        [HttpPost("register/company")]
        public async Task<ActionResult> RegisterCompany([FromBody] RegisterCompanyAccountDto dto)
        {
            await _accountService.RegisterCompanyAccount(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
