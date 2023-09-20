using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Applications.Utils;
using UpSkills.Persistance.Dto.Videos;
using UpSkills.Persistance.Validations.Videos;
using UpSkills.Service.Interfaces.Videos;

namespace UpSkills.WebApi.Controllers;

[Route("api/videos")]
[ApiController]
public class VideoController : ControllerBase
{
    private IVideoService _service;
    private readonly int maxPageSize = 30;
    public VideoController(IVideoService service)
    {
        this._service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] VideoCreateDto dto)
    {
        var validator = new VideoCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{videoId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long videoId) => Ok(await _service.DeleteAsync(videoId));

    [HttpGet("{videoId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long videoId) => Ok(await _service.GetByIdAsync(videoId));

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchAsync(string search,[FromQuery] int page = 1)
        => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));
}