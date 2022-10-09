using System;
using System.ComponentModel.DataAnnotations;

namespace MyCash.Data.Dtos.CategoryDTO
{
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage = "É necessário informar o nome da categoria.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor informe se é uma categoria de receita ou despesa.")]
        [Display(Name = "Tipo da Categoria")]
        public bool isIncomeType { get; set; }
    }
}
