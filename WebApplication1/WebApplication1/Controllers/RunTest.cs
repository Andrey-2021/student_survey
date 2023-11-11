using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    //Клас отвечтает за прохождение теста пользователем

    [Authorize(Roles = "user")]
    public class RunTest : Controller
    {
        UserContext _context;
        static List<CreateTest>? allTests; //список доступных тестов

        static CreateTest? selectedTes; //выбранный тест
        static int selectedTestId = -1; //индекс выбранного теста
        static int questionCount = 0; //номер спрашиваемого вопроса
        static int? answersSum = 0;//сумма ответов

        public RunTest(UserContext context)
        {
            _context = context;
        }

        // GET: RunTest
        public ActionResult Index()
        {
            _context.Answers.Load();
            _context.Questions.Load();
            allTests = _context.CreateTests.ToList();

            return View(allTests);
        }

        //Выбор теста
        [HttpGet]
        public ActionResult SelectedTest(string? selectedId)
        {
            if (!string.IsNullOrEmpty(selectedId))
            {
                selectedTestId = int.Parse(selectedId);
                selectedTes = allTests?.FirstOrDefault(x => x.Id == selectedTestId);
            }
            answersSum = 0;
            questionCount = 1;
            ViewBag.QuestionCount = questionCount;

            return View("ShowQuestion", selectedTes);
        }

        //показываем вопрос
        [HttpPost]
        public ActionResult ShowQuestion(string anserIndex = "-1")
        {
            int n = int.Parse(anserIndex);


            if (n >= 0)
            {
                answersSum += selectedTes?.Questions[questionCount - 1].Answers[n].PointsNumber;
            }


            if (questionCount < selectedTes?.Questions.Count)
            {
                questionCount++;
                ViewBag.QuestionCount = questionCount;
                return View("ShowQuestion", selectedTes);
            }
            else
            {
                _context.CreateTests.Attach(selectedTes);

                TestExecution execution = new TestExecution();

                if (User.Identity.IsAuthenticated) //Если пользователь вошёл
                {
                    var name = User.Identity.Name;
                    var user = _context.Users.FirstOrDefault(x => x.Login == name); //ищём его в БД
                    if (user != null) execution.UserId = user?.Id;
                    else execution.UserId = 1;
                }
                else
                {
                    execution.UserId = 1;
                }

                execution.CreateTest = selectedTes;
                //execution.CreateTestId = selectedTes?.Id;
                execution.AnswersSum = answersSum;

                _context.TestExecutions.Add(execution);
                _context.SaveChanges();

                ViewBag.RightAnswers = answersSum;
                return View("TestEnd", selectedTes);
            }
        }
    }
}
