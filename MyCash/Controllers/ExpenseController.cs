using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCash.Data;
using MyCash.Data.Dtos.ExpenseDTO;
using MyCash.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyCash.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExpenseController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ExpenseController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddExpense([FromBody] ExpenseCreateDTO expenseCreateDto)
        {
            Expense expense = _mapper.Map<Expense>(expenseCreateDto);

            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetExpenseById), new { Id = expense.Id }, expense);
        }

        [HttpGet]
        public IEnumerable<Expense> GetExpense() 
        { 
            return _context.Expenses;
        }

        [HttpGet("{Id}")]
        public IActionResult GetExpenseById(int Id)
        {

            Expense expense = _context.Expenses.FirstOrDefault(expense => expense.Id == Id);
            if (expense != null)
            {
                ExpenseReadDTO expenseDTO = _mapper.Map<ExpenseReadDTO>(expense);
                return Ok(expenseDTO);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateExpenseById(int Id, [FromBody] ExpenseCreateDTO expenseDTO)
        {
            Expense expense = _context.Expenses.FirstOrDefault(expense => expense.Id == Id);
            if (expense == null)
            {
                return NotFound();
            }
            _mapper.Map(expenseDTO, expense);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteExpenseById(int Id)
        {
            Expense expense = _context.Expenses.FirstOrDefault(expense => expense.Id == Id);
            if (expense == null)
            {
                return NotFound();
            }
            _context.Remove(expense);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
