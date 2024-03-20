using KursovayaKP.Models;
using KursovayaKP.Models.TablesDB;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace KursovayaKP.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<QuestionTable> _dbOptionsQuestionTable;
        private readonly DbContextOptions<TableAnswerUserTest> _dbOptionsAnswerUserTest;
        private readonly DbContextOptions<TestTable> _dbOptionsTestTable;
        private readonly ILogger<AdminController> _logger;

        public HomeController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, DbContextOptions<TestTable> dbOptionsTestTable, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
            _dbOptionsTestTable = dbOptionsTestTable;
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

		public IActionResult Test(int categoryID)
		{
			Console.WriteLine("Путь " + categoryID);
			TestTable testTable = new TestTable(_dbOptionsTestTable);
			int randomTestId = testTable.GetRandomTestId(categoryID);
            Console.WriteLine(randomTestId);
            QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
            List<QuestionModel> questions = questionTable.GetRandomQuestionsTest(randomTestId);
            return View(questions);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Сохранение ответов пользователей
        [HttpPost]
        public ActionResult SubmitAnswers(AnswerUserTestModel answerUserTestModel)
        {
            Console.WriteLine(answerUserTestModel.UserId + " " + answerUserTestModel.TestId + " " + answerUserTestModel.ResultTest);

            // Проверка валидности объекта
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new TableAnswerUserTest(_dbOptionsAnswerUserTest))
                    {
                        bool isAdded = db.AddAnswer(answerUserTestModel);
                        // Возвращаем результат в формате JSON
                        return Json("Результаты тестасохранены");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка при добавлении ответа пользователя в БД");
                    return Json("Ошибка при добавлении ответа пользователя в БД");
                }
            }
            return Json("Некорректные данные");
        }
    }
}
