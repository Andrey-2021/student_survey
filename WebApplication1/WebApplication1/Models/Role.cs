using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public class Role
    {
        public int Id { get; set; }

        /// <summary>
        /// Название роли
        /// </summary>
        [Required(ErrorMessage = "Не ввели название роли")]
        public string Name { get; set; }
        
        /// <summary>
        /// Список пользователей с такой ролью
        /// </summary>
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
