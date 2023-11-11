using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан ФИО")]
        public string Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(14, 60, ErrorMessage ="Возраст должен быть от 14 и до 60")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }


        /// <summary>
        /// Группа
        /// </summary>
        //public int? GroupId { get; set; }

        [Required(ErrorMessage = "Не выбрана группа")]
        public int GroupId { get; set; }

    }
}
