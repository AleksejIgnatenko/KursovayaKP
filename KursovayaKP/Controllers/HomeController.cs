using KursovayaKP.Models;
using KursovayaKP.Models.QuestionTableModelDB;
using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace KursovayaKP.Controllers
{
	public class HomeController : Controller
	{
        private readonly DbContextOptions<TableQuestionTrafficRegulations> _dbOptionsTrafficRegulations;
        private readonly ILogger<HomeController> _logger;

		public HomeController(DbContextOptions<TableQuestionTrafficRegulations> dbOptionsTrafficRegulations, ILogger<HomeController> logger)
		{
            _dbOptionsTrafficRegulations = dbOptionsTrafficRegulations;
            _logger = logger;
		}

		public IActionResult Index()
		{
			var role = HttpContext.Request.Cookies["Role"];

			if (role == "Admin")
			{
				return RedirectToAction("AdminIndex", "Admin");
			}

			return View();
		}

		public IActionResult TrafficRegulations()
		{
			return View();
		}

		public IActionResult RoadSigns()
		{
			return View();
		}

        public IActionResult MedicalCare()
        {
            return View();
        }

        public IActionResult CarDevice()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestTrafficRegulations()
        {
            TableQuestionTrafficRegulations tableQuestionTrafficRegulations = new TableQuestionTrafficRegulations(_dbOptionsTrafficRegulations);
            List<QuestionsTrafficRegulationsModel> allQuestions = tableQuestionTrafficRegulations.GetAllQuestionsTrafficRegulations(); // Retrieve questions from the table
            List<QuestionsTrafficRegulationsModel> selectedQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
            return View("~/Views/Home/tests/TestTrafficRegulations.cshtml", selectedQuestions);
        }


        // Проверка ответов теста ПДД
        int counter = 0;

/*        [HttpPost]
        public IActionResult CheckTestTrafficRegulation(int questionID, string answer)
        {
            Console.WriteLine(questionID);
            return View("~/Views/Home/tests/TestTrafficRegulations.cshtml");
        }*/
    }
}
