using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Api.Controllers
{
    /// <summary>
    /// Entrypoint for other microservice to send data for analyzing.
    /// </summary>
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

        /// <summary>
        /// Receives the data and then proceeds to analyze it. if there is need create alerts and critical alerts.
        /// </summary>
        /// <param name="dataRecord">Data record to be analyzed</param>
        /// <response code="204">Operation completed successfully, Data record analyzed.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("process")]
        public async Task<IActionResult> ReceiveDataRecord(DataRecordDto dataRecord)
        {
            await _alertService.ProcessNewRecordAsync(dataRecord);
            await _criticalAlertService.ProcessNewRecordAsync(dataRecord);
            return NoContent();
        }
    }
}