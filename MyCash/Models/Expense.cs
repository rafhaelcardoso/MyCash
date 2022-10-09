using System;
using System.ComponentModel.DataAnnotations;

namespace MyCash.Models
{
    public class Expense
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Valor")]
        public decimal Amount { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
    }
}
