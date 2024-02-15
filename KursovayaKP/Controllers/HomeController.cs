using KursovayaKP.Models;
using KursovayaKP.Models.QuestionTableModelDB;
using KursovayaKP.Tables;
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
        private readonly DbContextOptions<TableQuestionRoadSigns> _dbOptionsRoadSigns;
        private readonly DbContextOptions<TableQuestionMedicalCare> _dbOptionsMedicalCare;
        private readonly DbContextOptions<TableQuestionCarDevice> _dbOptionsCarDevice;
        private readonly DbContextOptions<TableAnswerUserTest> _dbOptionsAnswerUserTest;
        private readonly ILogger<AdminController> _logger;

        public HomeController(DbContextOptions<TableQuestionTrafficRegulations> dbOptionsTrafficRegulations, DbContextOptions<TableQuestionRoadSigns> dbOptionsRoadSigns, DbContextOptions<TableQuestionMedicalCare> dbOptionsMedicalCare, DbContextOptions<TableQuestionCarDevice> dbOptionsCarDevice, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, ILogger<AdminController> logger)
        {
            _dbOptionsTrafficRegulations = dbOptionsTrafficRegulations;
            _dbOptionsRoadSigns = dbOptionsRoadSigns;
            _dbOptionsMedicalCare = dbOptionsMedicalCare;
            _dbOptionsCarDevice = dbOptionsCarDevice;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
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

        /*        public IActionResult CheckingAnswer()
                {
                    return View("~/Views/Home/Tests/CheckingAnswer.cshtml", selectedQuestions);
                }*/

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
            try
            {
                TableQuestionTrafficRegulations tableQuestionTrafficRegulations = new TableQuestionTrafficRegulations(_dbOptionsTrafficRegulations);
                List<QuestionsTrafficRegulationsModel> allQuestions = tableQuestionTrafficRegulations.GetAllQuestionsTrafficRegulations(); // Retrieve questions from the table
                List<QuestionsTrafficRegulationsModel> selectedQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
                return View("~/Views/Home/Tests/TestTrafficRegulations.cshtml", selectedQuestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения теста");
                return Json("Ошибка получения теста");
            }
        }


        // Сохранение ответов пользователей
        // Метод, принимающий результаты теста
        [HttpPost]
        public ActionResult SubmitAnswers(int userId, string nameTest,int resultTest)
        {
            Console.WriteLine(userId + " " + resultTest);

            AnswerUserTestModel answerUserTestModel = new AnswerUserTestModel
            {
                UserId = userId,
                NameTest = nameTest,
                ResultTest = resultTest
            };

            // Проверка валидности объекта
            if (TryValidateModel(answerUserTestModel))
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
