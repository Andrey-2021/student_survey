using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    //пройденых тестов по группы
    //Структура для статистики по группам
    public struct TestStatistic
    {
        public CreateTest Test { get; set; } //опрос
        public List<Group> Groups { get; set; } //Список групп, которые прошли этот тест
    }


    public class GroupsStatistic
    {
        UserContext _context;
        public GroupsStatistic(UserContext context)
        {
            _context = context;
        }

        //public List<TestStatistic>? TestStatistics { get; set; } //Статистика

        public List<CreateTest> CreateTests { get; set; }
        public List<TestExecution> TestExecutions { get; set; }
        public List<Group> Groups { get; set; }

    //загрузка данных из БД в списки
    public void SetDataToList()
        {
            _context.Groups.Load();
            _context.Answers.Load();
            _context.Questions.Load();
            _context.Roles.Load();
            _context.Users.Load();
            _context.TestExecutions.Load();

            TestExecutions = _context.TestExecutions.ToList();
            CreateTests = _context.CreateTests.ToList();
            Groups = _context.Groups.ToList();
        }
    }
}
