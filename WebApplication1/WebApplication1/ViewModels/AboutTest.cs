using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.ViewModels
{
    /// <summary>
    /// Информация о тестах и результаты прохождения тестов
    /// </summary>
    public class AboutTest
    {
        //Структура для статистики
        public struct Statistic
        {
            public CreateTest Test { get; set; } //опрос
            public int To30 { get; set; } //количество человек набравших  <=30% от максимального количества баллов
            public int To60 { get; set; }//количество человек набравших  от (30  до 60]% от максимального количества баллов
            public int To100 { get; set; }//количество человек набравших от (60 до 100]% от максимального количества баллов
        }


        public List<CreateTest>? CreateTests { get; set; } //список тестов
        public List<TestExecution>? TestExecutions { get; set; } //список пройденных опросов
        public List<Statistic>? StatInfo { get; set; } //Статистика

        UserContext _context;
        public AboutTest(UserContext context)
        {
            _context = context;
        }

        //загрузка данных из БД в списки
        public void SetDataToList()
        {
            _context.Groups.Load();
            _context.Answers.Load();
            _context.Questions.Load();
            _context.Roles.Load();
            _context.Users.Load();
            

            CreateTests = _context.CreateTests.ToList();
            TestExecutions = _context.TestExecutions.ToList();


            //Вычисляем статистику
            StatInfo = new List<Statistic>();

            for (int i = 0; i < CreateTests.Count; i++) //перебираем тесты
            {
                Statistic statistic = new Statistic();
                statistic.Test = CreateTests[i];
                statistic.To30 = 0;
                statistic.To60 = 0;
                statistic.To100 = 0;

                for (int j = 0; j < TestExecutions.Count; j++)
                {
                    if(TestExecutions[j].CreateTest.Id == CreateTests[i].Id)
                    {
                        var ball = 100 * TestExecutions[j].AnswersSum / CreateTests[i].MaxSum;

                        if (ball <= 30 ) statistic.To30++;
                        else
                        {
                            if (ball <= 60) statistic.To60++;
                            else
                            {
                                statistic.To100++;
                            }
                        }
                    }
                }
                StatInfo.Add(statistic);
            }

        }
    }
}
