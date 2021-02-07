using System;
using System.Threading.Tasks;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Domain.Interfaces.Repositories;
using SeoulAir.Analytics.Domain.Interfaces.Services;
using SeoulAir.Analytics.Domain.Services.Extensions;
using static SeoulAir.Analytics.Domain.Resources.Strings;

namespace SeoulAir.Analytics.Domain.Services
{
    public class CrudBaseService<TDto> : ICrudBaseService<TDto>
        where TDto : BaseDtoWithId
    {
        protected readonly ICrudBaseRepository<TDto> BaseRepository;

        public CrudBaseService(ICrudBaseRepository<TDto> baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task<string> AddAsync(TDto entity)
        {
            return await BaseRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await BaseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(TDto entity)
        {
            await BaseRepository.UpdateAsync(entity);
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            return await BaseRepository.GetByIdAsync(id);
        }

        public async Task<PaginatedResultDto<TDto>> GetPaginatedAsync(Paginator paginator)
        {
            CheckTypeProperties(paginator);

            return await BaseRepository.GetPaginated(paginator);
        }
        
        private void CheckTypeProperties(Paginator paginator)
        {
            if (!typeof(TDto).HasPublicProperty(paginator.OrderBy))
                throw new ArgumentException(string.Format(PaginationOrderError, paginator.OrderBy));

            if (paginator.FilterBy != null && !typeof(TDto).HasPublicProperty(paginator.FilterBy))
                throw new ArgumentException(string.Format(PaginationFilterError, paginator.FilterBy));
        }
    }
}
