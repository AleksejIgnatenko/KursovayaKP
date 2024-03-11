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
        private readonly ILogger<AdminController> _logger;

        public AdminController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, DbContextOptions<UserTable> dbOptionsUserTable, DbContextOptions<TestTable> dbOptionsTestTable, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
            _dbOptionsUserTable = dbOptionsUserTable;
            _dbOptionsTestTable = dbOptionsTestTable;
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

        public async Task<ActionResult> GetAllTests()
        {
            TestTable testTable = new TestTable(_dbOptionsTestTable);
            TestModel[] allTests = testTable.GetAllTest();

            return Json(allTests);
        }

        public IActionResult AllQuestions(string topic)
        {
            Console.WriteLine(topic);
            switch (topic)
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
            }
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
            Console.WriteLine(questionId);
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
            Console.WriteLine(question.IdQuestion + " " + question.QuestionText + " " + question.Answer1 + " " + question.Answer2 + " " + question.Answer3
                + " " + question.Answer4 + " " + question.CorrectAnswer);
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
        public IActionResult AddQuestionTrafficRegulations(QuestionModel questionModel)
        {
            questionModel.Topic = QuestionModel.Section.TrafficRegulations.ToString();
            return CheckingAddQuestion(questionModel, "~/Views/Admin/AddQuestions/AddQuestionTrafficRegulations.cshtml", "~/Views/Admin/AddQuestions/AddQuestionTrafficRegulations.cshtml");
        }

        [HttpPost]
        public IActionResult AddQuestionRoadSigns(QuestionModel questionModel)
        {
            questionModel.Topic = QuestionModel.Section.RoadSigns.ToString();
            return CheckingAddQuestion(questionModel, "~/Views/Admin/AddQuestions/AddQuestionRoadSigns.cshtml", "~/Views/Admin/AddQuestions/AddQuestionRoadSigns.cshtml");
        }

        [HttpPost]
        public IActionResult AddQuestionMedicalCare(QuestionModel questionModel)
        {
            questionModel.Topic = QuestionModel.Section.MedicalCare.ToString();
            return CheckingAddQuestion(questionModel, "~/Views/Admin/AddQuestions/AddQuestionMedicalCare.cshtml", "~/Views/Admin/AddQuestions/AddQuestionMedicalCare.cshtml");
        }

        [HttpPost]
        public IActionResult AddQuestionCarDevice(QuestionModel questionModel)
        {
            questionModel.Topic = QuestionModel.Section.CarDevice.ToString();
            return CheckingAddQuestion(questionModel, "~/Views/Admin/AddQuestions/AddQuestionCarDevice.cshtml", "~/Views/Admin/AddQuestions/AddQuestionCarDevice.cshtml");
        }

        [HttpPost]
        public IActionResult AddQuestions(QuestionModel questionModel)
        {
            switch (questionModel.Topic)
            {
                case "1":
                    questionModel.Topic = "TrafficRegulations";
                    break;
                case "2":
                    questionModel.Topic = "RoadSigns";
                    break;
                case "3":
                    questionModel.Topic = "MedicalCare";
                    break;
                case "4":
                    questionModel.Topic = "CarDevice";
                    break;
                default: throw new Exception("Ошибка выбора раздела длядобавления вопроса");
            }

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
                userResults[0] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.TrafficRegulations.ToString());
                userResults[1] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.RoadSigns.ToString());
                userResults[2] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.MedicalCare.ToString());
                userResults[3] = tableAnswerUserTest.GetRatingsTest(userId, QuestionModel.Section.CarDevice.ToString());

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
            Console.WriteLine(testModel.IdTest + " " + testModel.NameTest);
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("true");
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
