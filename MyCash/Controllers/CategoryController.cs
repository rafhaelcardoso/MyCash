using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCash.Data;
using MyCash.Data.Dtos.CategoryDTO;
using MyCash.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyCash.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryCreateDTO categoryCreateDto)
        {
            Category category = _mapper.Map<Category>(categoryCreateDto);

            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoryById), new { Id = category.Id }, category);
        }

        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories;
        }

        [HttpGet("{Id}")]
        public IActionResult GetCategoryById(int Id)
        {

            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            if (category != null)
            {
                CategoryReadDTO categoryDTO = _mapper.Map<CategoryReadDTO>(category);
                return Ok(categoryDTO);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCategoryById(int Id, [FromBody] CategoryCreateDTO categoryDto)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryDto, category);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCategoryById(int Id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
