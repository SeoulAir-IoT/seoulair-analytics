using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataRecordController : ControllerBase
    {
        private readonly IAlertService _alertService;
        private readonly ICriticalAlertService _criticalAlertService;

        public DataRecordController(IAlertService alertService, ICriticalAlertService criticalAlertService)
        {
            _alertService = alertService;
            _criticalAlertService = criticalAlertService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ReceiveDataRecord(DataRecordDto dataRecord)
        {
            await _alertService.ProcessNewRecordAsync(dataRecord);
            await _criticalAlertService.ProcessNewRecordAsync(dataRecord);
            return Ok();
        }
    }
}