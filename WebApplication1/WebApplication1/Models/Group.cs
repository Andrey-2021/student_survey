using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    /// <summary>
    /// Группа
    /// </summary>
    public class Group
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required(ErrorMessage = "Не ввели название группы")]
        public string Name { get; set; }
    }
}
