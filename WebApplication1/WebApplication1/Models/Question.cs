using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        [Required(ErrorMessage = "Не составлен вопрос")]
        public string? Title { get; set; }

         /// <summary>
        /// Список ответов
        /// </summary>
        public List<Answer>? Answers { get; set; }

        /// <summary>
        /// Ссылка на тест, к которому относится вопрос
        /// </summary>
        public int? TestId { get; set; }
        public CreateTest? Test { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
