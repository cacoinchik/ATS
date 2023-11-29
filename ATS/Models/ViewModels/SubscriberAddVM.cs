using System.ComponentModel.DataAnnotations;

namespace ATS.Models.ViewModels
{
    public class SubscriberAddVM
    {
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Введите почтовый адрес")]
        public string Email { get; set; }

    }
}
