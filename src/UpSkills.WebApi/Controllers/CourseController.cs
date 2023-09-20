using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Applications.Utils;
using UpSkills.Persistance.Dto.Courses;
using UpSkills.Persistance.Validations.Courses;
using UpSkills.Service.Interfaces.Courses;

namespace UpSkills.WebApi.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private ICourseService _service;
    private readonly int maxPageSize = 30;

    public CourseController(ICourseService service)
    {
        this._service = service;
    }

    [HttpPost]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto dto)
    {
        var validator = new CourseCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpPut("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto dto)
    {
        var validate = new CourseUpdateValidator();
        var result = validate.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(courseId,dto));
        else return BadRequest(result.Errors);
    }

    [HttpGet("{courseId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long courseId) => Ok(await _service.GetByIdAsync(courseId));

    [HttpDelete("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long courseId) => Ok(await _service.DeleteAsync(courseId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
        => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));
}