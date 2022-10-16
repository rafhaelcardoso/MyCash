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
            CreateMap<Income, IncomeReadDTO>();

            //Expense Mapping
            CreateMap<ExpenseCreateDTO, Expense>();
            CreateMap<Expense, ExpenseReadDTO>();

            //Category Mapping
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryReadDTO>();
        }
    }
}
