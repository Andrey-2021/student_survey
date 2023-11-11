using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{

    /// <summary>
    /// Ответ для теста
    /// </summary>
    public class Answer
    {
        public int Id { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        [Required(ErrorMessage = "Не составлен ответ")]
        public string Text { get; set; }

        /// <summary>
        /// Количество баллов за ответ
        /// </summary>
        [Required(ErrorMessage = "Не указали количество баллов за ответ")]
        [Range(1, 100, ErrorMessage = "Количество баллов должно быть от 1 и до 100")]
        public int PointsNumber { get; set; }

        /// <summary>
        /// Ссылка на Вопрос, к которому относится ответ
        /// </summary>
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
