using KursovayaKP.Models;
using KursovayaKP.Models.TablesDB;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContextOptions<QuestionTable> _dbOptionsQuestionTable;
        private readonly DbContextOptions<TableAnswerUserTest> _dbOptionsAnswerUserTest;
        private readonly DbContextOptions<UserTable> _dbOptionsUserTable;
        private readonly DbContextOptions<TestTable> _dbOptionsTestTable;
        private readonly DbContextOptions<CategoryTable> _dbOptionsCategoryTable;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, DbContextOptions<UserTable> dbOptionsUserTable, DbContextOptions<TestTable> dbOptionsTestTable, DbContextOptions<CategoryTable> dbOptionsCategoryTable, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
            _dbOptionsUserTable = dbOptionsUserTable;
            _dbOptionsTestTable = dbOptionsTestTable;
            _dbOptionsCategoryTable = dbOptionsCategoryTable;
            _logger = logger;
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult AddQuestionTrafficRegulations()
        {
            return View("~/Views/Admin/AddQuestions/AddQuestionTrafficRegulations.cshtml");
        }

        public IActionResult AddQuestionRoadSigns()
        {
            return View("~/Views/Admin/AddQuestions/AddQuestionRoadSigns.cshtml");
        }

        public IActionResult AddQuestionMedicalCare()
        {
            return View("~/Views/Admin/AddQuestions/AddQuestionMedicalCare.cshtml");
        }

        public IActionResult AddQuestionCarDevice()
        {
            return View("~/Views/Admin/AddQuestions/AddQuestionCarDevice.cshtml");
        }

        public IActionResult AdminTrafficRegulations()
        {
            return View("~/Views/Admin/AdminHome/AdminTrafficRegulations.cshtml");
        }

        public IActionResult AdminRoadSigns()
        {
            return View("~/Views/Admin/AdminHome/AdminRoadSigns.cshtml");
        }

        public IActionResult AdminMedicalCare()
        {
            return View("~/Views/Admin/AdminHome/AdminMedicalCare.cshtml");
        }

        public IActionResult AdminCarDevice()
        {
            return View("~/Views/Admin/AdminHome/AdminCarDevice.cshtml");
        }

		public IActionResult AddQuestions()
		{
			return View();
		}

		public IActionResult AddTest()
        {
            return View();
        }

        public IActionResult AllUsers()
        {
            try
            {
                UserTable userTable = new UserTable(_dbOptionsUserTable);
                List<UserModel> allUsers = userTable.GetAllUsers();
                return View(allUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View();
        }

        public IActionResult AllQuestions(string topic)
        {
            /*switch (topic)
            {
                case "TrafficRegulations":
                    try
                    {
                        QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                        List<QuestionModel> allquestions = questionTable.GetAllQuestions();
                        List<QuestionModel> questionTrafficRegulations = allquestions.Where(q => q.Topic == QuestionModel.Section.TrafficRegulations.ToString()).ToList();
                        ViewBag.Topic = "ПДД";
                        return View(questionTrafficRegulations);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка получения всех вопросов по теме");
                    }
                    break;

                case "RoadSigns":
                    try
                    {
                        QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                        List<QuestionModel> allquestions = questionTable.GetAllQuestions();
                        List<QuestionModel> questionTrafficRegulations = allquestions.Where(q => q.Topic == QuestionModel.Section.RoadSigns.ToString()).ToList();
                        ViewBag.Topic = "Дорожные знаки";
                        return View(questionTrafficRegulations);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка получения всех вопросов по теме");
                    }
                    break;

                case "MedicalCare":
                    try
                    {
                        QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                        List<QuestionModel> allquestions = questionTable.GetAllQuestions();
                        List<QuestionModel> questionTrafficRegulations = allquestions.Where(q => q.Topic == QuestionModel.Section.MedicalCare.ToString()).ToList();
                        ViewBag.Topic = "Первая медецинская помощь";
                        return View(questionTrafficRegulations);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка получения всех вопросов по теме");
                    }
                    break;

                case "CarDevice":
                    try
                    {
                        QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                        List<QuestionModel> allquestions = questionTable.GetAllQuestions();
                        List<QuestionModel> questionTrafficRegulations = allquestions.Where(q => q.Topic == QuestionModel.Section.CarDevice.ToString()).ToList();
                        ViewBag.Topic = "Устройство авто";
                        return View(questionTrafficRegulations);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка получения всех вопросов по теме");
                    }
                    break;
            }*/
            return View();
        }

        [HttpPost]
        public IActionResult DeleteQuestion(int questionId)
        {
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                bool isDeleted = questionTable.DeleteQuestion(questionId);
                if (isDeleted)
                {
                    return RedirectToAction("AllQuestions");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления вопроса");
            }

            // Обработка ошибки удаления
            return RedirectToAction("AllQuestions");
        }

        [HttpPost]
        public IActionResult QuestionForUpdate(int questionId)
        {
            QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
            QuestionModel? question = questionTable.GetQuestion(questionId);
            if (question != null)
            {
                return View(question);
            }
            return View();
        }

        [HttpPost]
        public IActionResult QuestionUpdate(QuestionModel question)
        {
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                questionTable.UpdateQuestion(question);
                return View("~/Views/Admin/QuestionForUpdate.cshtml", question);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка редактирования");
            }
            return View("~/Views/Admin/QuestionForUpdate.cshtml", question);
        }

        [HttpPost]
        public TestModel[] GetAllTests()
        {
            TestTable testTable = new TestTable(_dbOptionsTestTable);
            TestModel[] allTests = testTable.GetAllTest();
            //Console.WriteLine(allTests[0].IdTest + " " + allTests[0].NameTest);
			return allTests;
        }

        [HttpPost]
        public CategoryModel[] GetAllCategory()
        {
            CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
            CategoryModel[] categories = categoryTable.GetAllCategory();
            return categories;
        }

        [HttpPost]
		public IActionResult AddQuestions(QuestionModel questionModel)
		{
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View(questionModel);
                }

                try
                {
                    using (var db = new QuestionTable(_dbOptionsQuestionTable))
                    {
                        bool isAdded = db.AddQuestion(questionModel);
                        if (isAdded)
                        {
                            ModelState.Clear(); // Очистить состояние модели
                            return View();
                        }
                        else
                        {
                            ModelState.AddModelError("QuestionText", "Вопрос с таким текстом уже существует.");
                            return View(questionModel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка добавления вопроса в БД");
                    return Json("Ошибка добавления вопроса в БД");
                }
            }
            return View(questionModel);
        }


        [HttpPost]
        public ActionResult<double[]> GetDetailedUserInformation(int userId)
        {
            try
            {
                double[] userResults = new double[4];
                TableAnswerUserTest tableAnswerUserTest = new TableAnswerUserTest(_dbOptionsAnswerUserTest);
/*                userResults[0] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.TrafficRegulations.ToString());
                userResults[1] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.RoadSigns.ToString());
                userResults[2] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.MedicalCare.ToString());
                userResults[3] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.CarDevice.ToString());*/

                return Ok(userResults);
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                _logger.LogError(ex, "Ошибка получения результатов");
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult AddTest(TestModel testModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine(testModel.IdCategory + " " + testModel.NameTest);
                    TestTable test = new TestTable(_dbOptionsTestTable);
                    test.AddTest(testModel);
                    ModelState.Clear();
                    return View("~/Views/Admin/AddTest.cshtml");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка добавления теста");
            }
            return View("~/Views/Admin/AddTest.cshtml");
        }


        public IActionResult CheckingAddQuestion(QuestionModel questionModel, string errorPage, string addingQuestionCorrectly)
        {
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View(errorPage, questionModel);
                }

                try
                {
                    using (var db = new QuestionTable(_dbOptionsQuestionTable))
                    {
                        bool isAdded = db.AddQuestion(questionModel);
                        if (isAdded)
                        {
                            ModelState.Clear(); // Очистить состояние модели
                            return View(addingQuestionCorrectly);
                        }
                        else
                        {
                            ModelState.AddModelError("QuestionText", "Вопрос с таким текстом уже существует.");
                            return View(errorPage, questionModel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка добавления вопроса в БД");
                    return Json("Ошибка добавления вопроса в БД");
                }
            }
            return View(errorPage, questionModel);
        }
    }
}
