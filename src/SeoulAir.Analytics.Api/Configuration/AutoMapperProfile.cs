using AutoMapper;
using SeoulAir.Analytics.Domain.Dtos;
using SeoulAir.Analytics.Repositories.Entities;

namespace SeoulAir.Analytics.Api.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            #region Dtos - Entities

            CreateMap<BaseDtoWithId, BaseEntityWithId>().ReverseMap();
            CreateMap<CriticalAlertDto, CriticalAlert>().ReverseMap();
            CreateMap<AlertDto, Alert>().ReverseMap();

            #endregion
        }
    }
}