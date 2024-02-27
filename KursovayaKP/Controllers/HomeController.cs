using KursovayaKP.Models;
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
        private readonly ILogger<AdminController> _logger;

        public HomeController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
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
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                List<QuestionModel> allQuestions = questionTable.GetAllQuestions(); // Retrieve questions from the table
                List<QuestionModel> selectedQuestions = allQuestions.Where(q => q.Topic == QuestionModel.Section.TrafficRegulations.ToString()).OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
                return View("~/Views/Home/Tests/TestTrafficRegulations.cshtml", selectedQuestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения теста");
                return Json("Ошибка получения теста");
            }
        }

        public IActionResult TestRoadSigns()
        {
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                List<QuestionModel> allQuestions = questionTable.GetAllQuestions(); // Retrieve questions from the table
                List<QuestionModel> selectedQuestions = allQuestions.Where(q => q.Topic == QuestionModel.Section.RoadSigns.ToString()).OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
                return View("~/Views/Home/Tests/TestRoadSigns.cshtml", selectedQuestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения теста");
                return Json("Ошибка получения теста");
            }
        }

        public IActionResult TestMedicalCare()
        {
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                List<QuestionModel> allQuestions = questionTable.GetAllQuestions(); // Retrieve questions from the table
                List<QuestionModel> selectedQuestions = allQuestions.Where(q => q.Topic == QuestionModel.Section.MedicalCare.ToString()).OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
                return View("~/Views/Home/Tests/TestMedicalCare.cshtml", selectedQuestions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения теста");
                return Json("Ошибка получения теста");
            }
        }

        public IActionResult TestCarDevice()
        {
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                List<QuestionModel> allQuestions = questionTable.GetAllQuestions(); // Retrieve questions from the table
                List<QuestionModel> selectedQuestions = allQuestions.Where(q => q.Topic == QuestionModel.Section.CarDevice.ToString()).OrderBy(x => Guid.NewGuid()).Take(10).ToList(); // Select random questions from the list
                return View("~/Views/Home/Tests/TestCarDevice.cshtml", selectedQuestions);
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
        public ActionResult SubmitAnswers(int userId, string path, int resultTest)
        {
            Console.WriteLine(path);
            Console.WriteLine(userId + " " + resultTest);

            AnswerUserTestModel answerUserTestModel = new AnswerUserTestModel
            {
                UserId = userId,
                ResultTest = resultTest
            };

            switch (path)
            {
                case "/Home/TestTrafficRegulations":
                    answerUserTestModel.NameTest = QuestionModel.Section.TrafficRegulations.ToString();
                    break;

                case "/Home/TestRoadSigns":
                    answerUserTestModel.NameTest = QuestionModel.Section.RoadSigns.ToString();
                    break;

                case "/Home/TestMedicalCare":
                    answerUserTestModel.NameTest = QuestionModel.Section.MedicalCare.ToString();
                    break;

                case "/Home/TestCarDevice":
                    answerUserTestModel.NameTest = QuestionModel.Section.CarDevice.ToString();
                    break;

                default:
                    Console.WriteLine("Путь не определен");
                    break;
            }

            Console.WriteLine(answerUserTestModel.UserId + " " + answerUserTestModel.NameTest + " " + answerUserTestModel.ResultTest);
            // Проверка валидности объекта
            if (TryValidateModel(answerUserTestModel))
            {
                Console.WriteLine(answerUserTestModel.UserId + " " + answerUserTestModel.NameTest + " " + answerUserTestModel.ResultTest);
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
