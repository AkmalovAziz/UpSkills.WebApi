using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Persistance.Dto.Auth;
using UpSkills.Persistance.Validations;
using UpSkills.Persistance.Validations.Auth;
using UpSkills.Service.Interfaces.Auth;

namespace UpSkills.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _service;

        public AuthController(IAuthService service)
        {
            this._service = service;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrAsync([FromForm] RegistrDto dto)
        {
            var validator = new RegistrValidator();
            var validatorResult = validator.Validate(dto);
            if (validatorResult.IsValid) 
            {
                var result = await _service.RegisterAsync(dto);

                return Ok(new { result.Result, result.CachedMinutes });
            } 
            else return BadRequest(validatorResult.Errors);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            var validator = new LoginValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) 
            {
                var Dbresult = await _service.LoginAsync(dto);
                return Ok(new { Dbresult.Result, Dbresult.Token });
            } 
            else return BadRequest(result.Errors);
        }

        [HttpPost("register/send-code")]
        [AllowAnonymous]
        public async Task<IActionResult> SendCodeAsync(string email)
        {
            var result = EmailValidations.IsValid(email);
            if (result == false) return BadRequest("Email is incorrected!");

            var registr = await _service.SendCodeForRegisterAsync(email);

            return Ok(new { registr.Result, registr.CachedVerificationMinutes });
        }

        [HttpPost("register/verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyAsync(VerifyDto dto)
        {
            var result = await _service.VerifyRegisterAsync(dto.Email, dto.Code);

            return Ok(new { result.Result, result.Token });
        }
    }
}