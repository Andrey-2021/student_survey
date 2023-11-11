using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{

    /// <summary>
    /// Класс отвечает за создание новых тестов
    /// </summary>
    [Authorize(Roles = "admin")]
    public class CreateTestController : Controller
    {
        static CreateTest? _test;
        Question _question;
        static int count = 0;
        static int maxSum = 0; //максимальная сумма баллов

        UserContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public CreateTestController(UserContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //создание нового теста
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewTest(CreateTest test)
        {
            if (ModelState.IsValid)//если поля введены правильно
            {
                _test = test;
                count = 1;
                maxSum = 0;

                ViewBag.QuestionCount = count;
                ViewBag.NumberChoiceInQuestio = _test.NumberChoiceInQuestion;

                return View("CreateNewQuestion");
            }
            else
            {
                return View("Index", test);
            }
        }

        //Создание нового вопроса

        [HttpPost]
        public ActionResult CreateNewQuestion(Question question)
        {
            question.Test = _test;
            question.Number = count;

            if (ModelState.IsValid) //если поля введены правильно
            {
                _test.Questions.Add(question);

                //находим максимальный бал среди баллов всех ответов этого вопроса
                int max = 0;
                for (int i = 0; i < question.Answers?.Count; i++)
                {
                    if (max < question.Answers[i].PointsNumber) max = question.Answers[i].PointsNumber;
                }
                maxSum += max;

                count++;
                ViewBag.QuestionCount = count;
                ViewBag.NumberChoiceInQuestio = _test?.NumberChoiceInQuestion;

                if (count <= _test?.NumberQuestions)
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    _test.MaxSum = maxSum;
                    _context.CreateTests.Add(_test);
                    _context.SaveChanges();

                    return View("QuestionEnd");
                }
            }
            else
            {
                return View(question);
            }
        }


        //список пройденных опросов
        List<TestExecution>? TestExecutions { get; set; }

        //удалить пройденный тест
        [HttpGet]
        public ActionResult DelExecution()
        {
            LoadExecutionDateFromDb();
            return View(TestExecutions);
        }

        //Загузка данных из БД
        void LoadExecutionDateFromDb()
        {
            _context.Answers.Load();
            _context.Questions.Load();
            _context.CreateTests.Load();
            _context.Roles.Load();
            _context.Users.Load();

            TestExecutions = _context.TestExecutions.ToList();
        }


        [HttpPost]
        public ActionResult DelExecution(string[] selectedId)
        {

            foreach (var item in selectedId) //перебираем полученные строки
            {

                if (int.TryParse(item, out var id)) //преобразуем строку в число
                {
                    //ищем запись в БД
                    var record = _context.TestExecutions.FirstOrDefault(x => x.Id == id);
                    
                    if (record != null) //если запись найдена
                    {
                        //удаляем её
                        _context.TestExecutions.Remove(record);
                        _context.SaveChanges();
                    }
                }
            }

            LoadExecutionDateFromDb();
            return View(TestExecutions);
        }




        //---- создание новой группы
        [HttpGet]
        public ActionResult CreateNewGroup()
        {
            _context.Groups.Load();

            ViewBag.GroupList = _context.Groups.ToList();
            return View();
        }

        //создание новой группы
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewGroup(Group group)
        {
            if (ModelState.IsValid)//если поля введены правильно
            {
                _context.Groups.Load();
                var list = _context.Groups.ToList();

                if (list.Find(x => x.Name.ToUpper() == group.Name.ToUpper()) == null)  //если группы с таким названием нет
                { //добавляем группу в в БД
                    _context.Groups.Add(group);
                    _context.SaveChanges();

                    list = _context.Groups.ToList();
                    ViewBag.Rezul = "Группа добавлена в БД";
                }
                else
                {
                    ViewBag.Rezul = "Группа с таким названием уже есть в БД";
                }

                return View("GroupAddRezult", list);
            }
            else
            {
                return View();
            }
        }


        //---- Информация по зарегистророванным пользователям
        [HttpGet]
        public ActionResult ShowUserInfo()
        {
           
            _context.Groups.Load();
            _context.Users.Load();

            ViewBag.UsersList = _context.Users.ToList();
            return View();
        }

    }
}
