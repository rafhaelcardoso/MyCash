using System;
using System.ComponentModel.DataAnnotations;

namespace MyCash.Data.Dtos.CategoryDTO
{
    public class CategoryReadDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome da categoria.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor informe se é uma categoria de receita ou despesa.")]
        [Display(Name = "Tipo da Categoria")]
        public bool isIncomeType { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Data de Criação")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
