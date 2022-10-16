using System;
using System.ComponentModel.DataAnnotations;

namespace MyCash.Data.Dtos.ExpenseDTO
{
    public class ExpenseCreateDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Valor")]
        public decimal Amount { get; set; }

        public int CategoryId { get; set; } = 8;

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
    }
}
