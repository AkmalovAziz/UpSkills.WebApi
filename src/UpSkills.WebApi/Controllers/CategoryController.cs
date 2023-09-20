using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Applications.Utils;
using UpSkills.Persistance.Dto.Categories;
using UpSkills.Persistance.Validations.Categories;
using UpSkills.Service.Interfaces.Categories;

namespace UpSkills.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        private readonly int maxPageSize = 30;

        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatAsync([FromForm] CategoryCreateDto dto)
        {
            var validator = new CategoryCreateValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
        {
            var validator = new CategoryUpdateValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long categoryId)
            => Ok(await _service.DeleteAsync(categoryId));

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("{categoryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long categoryId)
            => Ok(await _service.GetByIdAsync(categoryId));

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());
    }
}