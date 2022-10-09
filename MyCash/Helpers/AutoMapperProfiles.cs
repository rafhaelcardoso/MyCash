using AutoMapper;
using MyCash.Data.Dtos.CategoryDTO;
using MyCash.Data.Dtos.ExpenseDTO;
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

            //Expense Mapping
            CreateMap<ExpenseCreateDTO, Expense>();
            CreateMap<ExpenseReadDTO, ExpenseCreateDTO>();

            //Category Mapping
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryReadDTO, CategoryCreateDTO>();
        }
    }
}
