using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    /// <summary>
    /// Прохождение теста
    /// </summary>
    public class TestExecution
    {
        public int Id { get; set; }

        /// <summary>
        /// Пользователь, приходивший опрос
        /// </summary>
        public int? UserId { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Опрос, пройденный пользователем
        /// </summary>
        public int? CreateTestId {get;set;}
        public CreateTest? CreateTest { get;set;}

        /// <summary>
        /// Количество набранных баллов
        /// </summary>
        public int? AnswersSum { get; set; }
    }
}
