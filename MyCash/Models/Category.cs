using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCash.Models
{
    public class Category
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

        public virtual List<Income> Incomes { get; set; }

        public virtual List<Expense> Expenses { get; set; }
    }
}
