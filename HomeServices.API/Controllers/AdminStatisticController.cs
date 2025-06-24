using HomeServices.Application.DTOs;
using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeServices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminStatisticController : ControllerBase
    {
        private readonly IAdminStatisticService _statService;

        public AdminStatisticController(IAdminStatisticService statService)
        {
            _statService = statService;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<AdminStatisticDto>> GetStatistics()
        {
            var stats = await _statService.GetAdminStatisticsAsync();
            return Ok(stats);
        }
    }

}
