using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Applications.Utils;
using UpSkills.Persistance.Dto.Users;
using UpSkills.Persistance.Validations.Users;
using UpSkills.Service.Interfaces.Users;

namespace UpSkills.WebApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _service;
    private readonly int maxPageSize = 30;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    [HttpPut("{userId}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
    {
        var validator = new UserUpdateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(userId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpDelete("{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long userId) => Ok(await _service.DeleteAsync(userId));

    [HttpGet("{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long userId) => Ok(await _service.GetByIdAsync(userId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
        => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));
}