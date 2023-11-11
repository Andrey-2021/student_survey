namespace WebApplication1.Models
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public int? RoleId { get; set; }
        public Role? Role { get; set; }


        /// <summary>
        /// Группа
        /// </summary>
        public int? GroupId { get; set; }
        public Group? Group { get; set; }


    }
}
