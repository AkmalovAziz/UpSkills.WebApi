using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSkills.Applications.Utils;
using UpSkills.Persistance.Dto.Orders;
using UpSkills.Service.Interfaces.Orders;

namespace UpSkills.WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        private readonly int maxPageSize = 30;

        public OrderController(IOrderService orderService)
        {
            this._service = orderService;
        }

        [HttpPost]
        [Authorize(Roles ="Admin, User")]
        public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

        [HttpDelete("{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long orderId)
            => Ok(await _service.DeleteAsync(orderId));

        [HttpGet("{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long orderId)
            => Ok(await _service.GetByIdAsync(orderId));

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAlldAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());
    }
}