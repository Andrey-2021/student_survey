using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
 /// <summary>
 /// Вход пользователя
 /// </summary>
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
