using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    /// <summary>
    /// Опрос
    /// </summary>
    public class CreateTest
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Название опроса
        /// </summary>
        [Required(ErrorMessage = "Не указано название")]
        public string? Name { get; set; }

        /// <summary>
        /// Описание опроса
        /// </summary>
        [Required(ErrorMessage = "Не указано описание")]
        public string? Description { get; set; }

        /// <summary>
        /// Количество вопросов в тесте
        /// </summary>
        [Required(ErrorMessage = "Не указано количество вопросов в опросе")]
        [Range(1, 30, ErrorMessage = "Количество вопросов должно быть от 1 и до 30")]
        public int NumberQuestions { get; set; }

        /// <summary>
        /// Количество вариантов ответов в каждом вопросе
        /// </summary>
        [Required(ErrorMessage = "Не указано количество вариантов ответов в каждом вопросе")]
        [Range(1, 20, ErrorMessage = "Количество вариантов ответов должно быть от 1 и до 20")]
        public int NumberChoiceInQuestion { get; set; }

        /// <summary>
        /// Текст результата
        /// </summary>
        [Required(ErrorMessage = "Не указан результат опроса")]
        public string? ResultText { get; set; }

        
        /// <summary>
        /// Максимальная сумма баллов за тест
        /// </summary>
        public int MaxSum { get; set; }

        /// <summary>
        /// Список вопросов данногог теста
        /// </summary>
        public List<Question> Questions { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public CreateTest()
        {
            Questions = new List<Question>();
        }

    }
}
