using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeServices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeReportsController : ControllerBase
    {
        private readonly IEmployeeReportsService _service;

        public EmployeeReportsController(IEmployeeReportsService service)
        {
            _service = service;
        }

        [HttpGet("combined")]
        public async Task<IActionResult> GetEmployeeCombinedReport()
        {
            var result = await _service.GetEmployeeCombinedReportAsync();
            return Ok(result);
        }
    }

}
