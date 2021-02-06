using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;

namespace SeoulAir.Analytics.Domain.Interfaces.Services
{
    public interface ICrudBaseService<TDto>
        where TDto : BaseDtoWithId
    {
        Task<TDto> AddAsync(TDto dto);
        Task DeleteAsync(string id);
        Task UpdateAsync(TDto entity);
        Task<TDto> GetByIdAsync(string id);
        Task<PaginatedResultDto<TDto>> GetPaginatedAsync(Paginator paginator);
    }
}