using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCash.Data;
using MyCash.Data.Dtos.IncomeDTO;
using MyCash.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyCash.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class IncomeController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public IncomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddIncome([FromBody] IncomeCreateDTO incomeCreateDto)
        {
            Income income = _mapper.Map<Income>(incomeCreateDto);

            _context.Incomes.Add(income);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetIncomeById), new { Id = income.Id }, income);
        }

        [HttpGet]
        public IEnumerable<Income> GetIncome() 
        { 
            return _context.Incomes;
        }

        [HttpGet("{Id}")]
        public IActionResult GetIncomeById(int Id)
        {

            Income income = _context.Incomes.FirstOrDefault(income => income.Id == Id);
            if (income != null)
            {
                IncomeReadDTO incomeDTO = _mapper.Map<IncomeReadDTO>(income);
                return Ok(incomeDTO);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateIncomeById(int Id, [FromBody] IncomeCreateDTO incomeDto)
        {
            Income income = _context.Incomes.FirstOrDefault(income => income.Id == Id);
            if (income == null)
            {
                return NotFound();
            }
            _mapper.Map(incomeDto, income);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteIncomeById(int Id)
        {
            Income income = _context.Incomes.FirstOrDefault(income => income.Id == Id);
            if (income == null)
            {
                return NotFound();
            }
            _context.Remove(income);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
