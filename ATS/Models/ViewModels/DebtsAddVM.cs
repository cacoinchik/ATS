using System.ComponentModel.DataAnnotations;

namespace ATS.Models.ViewModels
{
    public class DebtsAddVM
    {
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите сумму долга")]
        public decimal Amount { get; set; }

        public int SubscriberId { get; set; }

    }
}
