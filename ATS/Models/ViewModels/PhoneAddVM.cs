using System.ComponentModel.DataAnnotations;

namespace ATS.Models.ViewModels
{
    public class PhoneAddVM
    {
        [Required(ErrorMessage = "Введите модель телефона")]
        public string PhoneModel { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        public int SubscriberId { get; set; }
    }
}
