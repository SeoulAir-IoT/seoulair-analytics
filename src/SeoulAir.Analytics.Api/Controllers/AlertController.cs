using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Services;

namespace SeoulAir.Analytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly IAlertService _alertService;
        private readonly IMapper _mapper;

        public AlertController(IAlertService alertService, IMapper mapper)
        {
            _alertService = alertService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AlertDto>> GetByIdAsync(string id)
        {
            var result = await _alertService.GetByIdAsync(id);

            if (result == default)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedResultDto<AlertDto>>> GetPaginatedAsync(
            [FromQuery] Paginator paginator)
        {
            return Ok(await _alertService.GetPaginatedAsync(paginator));
        }
        
        [HttpPost]
        public async Task<ActionResult<AlertDto>> AddAsync(AlertDto alert)
        {
            return Ok(await _alertService.AddAsync(alert));
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            await _alertService.DeleteAsync(id);

            return NoContent();
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(AlertDto alert)
        {
            await _alertService.UpdateAsync(alert);

            return NoContent();
        }
    }
}