using AutoMapper;
using MyCash.Data.Dtos.IncomeDTO;
using MyCash.Models;

namespace MyCash.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Income Mapping
            CreateMap<IncomeCreateDTO, Income>();
            CreateMap<IncomeReadDTO, IncomeCreateDTO>();
        }
    }
}
