using MyCash.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyCash.Data.Dtos.IncomeDTO
{
    public class IncomeReadDTO
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

        [JsonIgnore]
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
    }
}
