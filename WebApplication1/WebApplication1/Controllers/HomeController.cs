using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{

    //Главный контроллер
    [Authorize]
    public class HomeController : Controller
    {
        UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour; //время сейчас
            string greeting;

            switch (hour)
            {
                case < 6:
                    greeting = "Доброй ночи";
                    break;
                case >= 6 and < 12:
                    greeting = "Доброй УТРО";
                    break;
                case >= 12 and < 18:
                    greeting = "Доброй день";
                    break;
                case >= 18 and < 24:
                    greeting = "Доброй вечер";
                    break;
                default:
                    greeting = "";
                    break;
            }

            ViewBag.Greeting = greeting;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public ViewResult ShowTestsList()
        {
            AboutTest aboutTest = new AboutTest(_context);
            aboutTest.SetDataToList();
            return View(aboutTest);
        }


        [AllowAnonymous]
        public ViewResult ShowGroupStattistic()
        {
            GroupsStatistic groupStatistic = new GroupsStatistic(_context);
            groupStatistic.SetDataToList();
            return View(groupStatistic);
        }
    }
}