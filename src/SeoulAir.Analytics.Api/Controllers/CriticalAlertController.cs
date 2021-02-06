using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Services;

namespace SeoulAir.Analytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriticalAlertController : ControllerBase
    {
        private readonly CriticalAlertService _criticalAlertService;
        private readonly IMapper _mapper;

        public CriticalAlertController(IMapper mapper, CriticalAlertService criticalAlertService)
        {
            _mapper = mapper;
            _criticalAlertService = criticalAlertService;
        }
        
        [HttpGet]
        public async Task<ActionResult<CriticalAlertDto>> GetByIdAsync(string id)
        {
            var result = await _criticalAlertService.GetByIdAsync(id);

            if (result == default)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedResultDto<CriticalAlertDto>>> GetPaginatedAsync(
            [FromQuery] Paginator paginator)
        {
            return Ok(await _criticalAlertService.GetPaginatedAsync(paginator));
        }
        
        [HttpPost]
        public async Task<ActionResult<CriticalAlertDto>> AddAsync(CriticalAlertDto alert)
        {
            return Ok(await _criticalAlertService.AddAsync(alert));
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            await _criticalAlertService.DeleteAsync(id);

            return NoContent();
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(CriticalAlertDto alertModel)
        {
            await _criticalAlertService.UpdateAsync(alertModel);

            return NoContent();
        }
    }
}