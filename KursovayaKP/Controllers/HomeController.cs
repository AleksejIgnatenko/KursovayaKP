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
        private readonly DbContextOptions<UserTable> _dbOptionsUserTable;
        private readonly DbContextOptions<TestTable> _dbOptionsTestTable;
        private readonly DbContextOptions<CategoryTable> _dbOptionsCategoryTable;
        private readonly ILogger<AdminController> _logger;

        public HomeController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, DbContextOptions<UserTable> dbOptionsUserTable, DbContextOptions<TestTable> dbOptionsTestTable, DbContextOptions<CategoryTable> dbOptionsCategoryTable, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
            _dbOptionsUserTable = dbOptionsUserTable;
            _dbOptionsTestTable = dbOptionsTestTable;
            _dbOptionsCategoryTable = dbOptionsCategoryTable;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var role = HttpContext.Request.Cookies["Role"];

            if ((role == "Admin") || (role == "Manager"))
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

		public IActionResult IdentificationMarks()
		{
			return View();
		}
        
		public IActionResult RoadMarkings()
		{
			return View();
		}    
        
		public IActionResult TrafficLight()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test(int categoryID)
        {
            if (Request.Cookies.TryGetValue("ID", out string? idCookie))
            {
                int idFromCookie;
                if (int.TryParse(idCookie, out idFromCookie))
                {
                    // ID найден в cookies, открываем тест
                    Console.WriteLine("ID категории из cookies: " + idFromCookie);
                    TestTable testTable = new TestTable(_dbOptionsTestTable);
                    int randomTestId = testTable.GetRandomTestId(categoryID);
                    QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                    List<QuestionModel>? questions = questionTable.GetRandomQuestionsTest(randomTestId);
                    
                    if(questions.Count != 10) 
                    {
                        questions = null;
                    }

                    CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
                    string? testName = categoryTable.GetNameCategory(categoryID);
                    ViewData["Title"] = $"Тест по теме \"{testName}\"";
                    return View(questions);
                }
            }

            // ID отсутствует в cookies, возвращаем другую страницу
            return View("~/Views/User/Registration.cshtml");
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
