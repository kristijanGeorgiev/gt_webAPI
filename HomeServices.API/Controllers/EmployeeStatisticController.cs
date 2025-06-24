using HomeServices.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeServices.API.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    public class EmployeeStatisticController : ControllerBase
    {
        private readonly IEmployeeStatisticService _service;

        public EmployeeStatisticController(IEmployeeStatisticService service)
        {
            _service = service;
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetStatistics(int employeeId)
        {
            var stats = await _service.GetStatisticsForEmployeeAsync(employeeId);
            return Ok(stats);
        }
    }

}
