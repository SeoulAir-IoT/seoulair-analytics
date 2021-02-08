using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;

namespace SeoulAir.Analytics.Domain.Interfaces.Repositories
{
    public interface ICrudBaseRepository<TDto>
        where TDto : BaseDtoWithId
    {
        Task<string> AddAsync(TDto entity);
        Task UpdateAsync(TDto entity);
        Task DeleteAsync(string id);
        Task<TDto> GetByIdAsync(string id);
        Task<PaginatedResultDto<TDto>> GetPaginated(Paginator paginator);
    }
}
