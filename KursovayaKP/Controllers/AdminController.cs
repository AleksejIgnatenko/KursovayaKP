using KursovayaKP.Models;
using KursovayaKP.Models.TablesDB;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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

		public IActionResult AddQuestions()
		{
			return View();
		}

		public IActionResult AddTest()
        {
            return View();
        }

        public CategoryModel? GetCategory(int categoryId)
        {
            Console.WriteLine(categoryId);
            CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
            CategoryModel? category = categoryTable.GetCategory(categoryId);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public IActionResult AllUsers()
        {
            var role = HttpContext.Request.Cookies["Role"];
            if (role == "Manager")
            {
                return RedirectToAction("Management", "Admin");
            }
            else
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
            }
            return View();
        }

        public IActionResult Management()
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

        public IActionResult AllTests()
        {
            try
            {
                TestTable testTable = new TestTable(_dbOptionsTestTable);
                TestModel[] allTests = testTable.GetAllTest();
                return View(allTests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View();
        }

        [HttpPost]
		public IActionResult DeleteTest(int testId)
		{
			Console.WriteLine($"ID теста {testId}");
			try
			{
				TestTable testTable = new TestTable(_dbOptionsTestTable);
				bool isRemove = testTable.DeleteTest(testId);
				if (isRemove)
				{
                    QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                    questionTable.DeletingTestQuestions(testId);
					return RedirectToAction("AllTests");
				}
				_logger.LogError("Тест не удален");

			}
			catch (Exception ex)
			{
				_logger.LogError($"{ex}");
			}
			return RedirectToAction("AllTests");
		}

        public IActionResult TestQuestions(int testId)
        {
            Console.WriteLine($"ID теста {testId}");
            try
            {
                QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
                QuestionModel[] questions = questionTable.GetQuestionsTestId(testId);

                TestTable testTable = new TestTable(_dbOptionsTestTable);
                string? topic = testTable.GetNameTest(testId);
                ViewBag.Topic = (topic != null) ? $"\"{topic}\"" : "";
				return View(questions);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return View();
            }
        }

        public IActionResult SetAdminRole(int id)
        {
            try
            {
                UserTable userTable = new UserTable(_dbOptionsUserTable);
                userTable.SetAdminRole(id);
                List<UserModel> allUsers = userTable.GetAllUsers();
                return View("~/Views/Admin/Management.cshtml", allUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View("~/Views/Admin/Management.cshtml");
        }

        public IActionResult DeleteAdminRole(int id)
        {
            try
            {
                UserTable userTable = new UserTable(_dbOptionsUserTable);
                userTable.DeleteAdminRole(id);
                List<UserModel> allUsers = userTable.GetAllUsers();
                return View("~/Views/Admin/Management.cshtml", allUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View("~/Views/Admin/Management.cshtml");
        }

        public IActionResult EditUserName(int id, string newUserName)
        {
            try
            {
                string pattern = "^[a-zA-Zа-яА-Я]+$";
                bool isValid = Regex.IsMatch(newUserName, pattern);

                if ((isValid) && (newUserName.Length > 1))
                {
                    UserTable userTable = new UserTable(_dbOptionsUserTable);
                    userTable.EditUserName(id, newUserName);
                    List<UserModel> allUsers = userTable.GetAllUsers();
                    return View("~/Views/Admin/Management.cshtml", allUsers);
                }
                else
                {
                    ModelState.AddModelError("UserName", "Неверное имя пользователя");
                    UserTable userTable = new UserTable(_dbOptionsUserTable);
                    List<UserModel> allUsers = userTable.GetAllUsers();
                    return View("~/Views/Admin/Management.cshtml", allUsers);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View("~/Views/Admin/Management.cshtml");
        }

        public IActionResult EditUserNameAdmin(int id, string newUserName)
        {
            Console.WriteLine(newUserName);
            Console.WriteLine(id);
            try
            {
                string pattern = "^[a-zA-Zа-яА-Я]+$";
                bool isValid = Regex.IsMatch(newUserName, pattern);

                if ((isValid) && (newUserName.Length > 1))
                {
                    UserTable userTable = new UserTable(_dbOptionsUserTable);
                    userTable.EditUserName(id, newUserName);
                    List<UserModel> allUsers = userTable.GetAllUsers();
                    return View("~/Views/Admin/AllUsers.cshtml", allUsers);
                }
                else
                {
                    ModelState.AddModelError("UserName", "Неверное имя пользователя");
                    UserTable userTable = new UserTable(_dbOptionsUserTable);
                    List<UserModel> allUsers = userTable.GetAllUsers();
                    return View("~/Views/Admin/AllUsers.cshtml", allUsers);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения всех пользователей");
            }
            return View("~/Views/Admin/AllUsers.cshtml");
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
		public IActionResult DeleteQuestion(int questionId, int testId)
		{
			try
			{
				QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
				bool isDeleted = questionTable.DeleteQuestion(questionId);
				if (isDeleted)
				{
					QuestionModel[] questions = questionTable.GetQuestionsTestId(testId);
					return View("TestQuestions", questions);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления вопроса");
			}

			// Обработка ошибки удаления
			return RedirectToAction("TestQuestions");
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
            /*            Console.WriteLine(question.IdQuestion + " " + question.IdTest + " " + question.QuestionText + " " + question.Answer1 + " " +
                        question.Answer2 + " " + question.Answer3 + " " + question.Answer4 + " " + question.CorrectAnswer);*/
            if (ModelState.IsValid)
            {
                var answers = new[] { question.Answer1, question.Answer2, question.Answer3, question.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == question.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View("~/Views/Admin/QuestionForUpdate.cshtml", question);
                }
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
            }
            return View("~/Views/Admin/QuestionForUpdate.cshtml", question);
        }

        public IActionResult TestForUpdate(int testId)
        {
            try
            {
                TestTable testTable = new TestTable(_dbOptionsTestTable);
                CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
                TestModel? test = testTable.GetTest(testId);
                if (test != null)
                {
                    CategoryModel[] categories = categoryTable.GetAllCategory();
                    var model = (test, categories);
                    return View(model);
                }
                return RedirectToAction("AllTests");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
            }
            return RedirectToAction("AllTests");
        }

        public IActionResult UpdateTest(TestModel test)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TestTable testTable = new TestTable(_dbOptionsTestTable);
                    CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
                    testTable.UpdateTest(test);
                    CategoryModel[] categories = categoryTable.GetAllCategory();
                    var model = (test, categories);
                    return View("~/Views/Admin/TestForUpdate.cshtml", model);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex}");
                }
            }
            return View("~/Views/Admin/AdminIndex.cshtml");
        }

        [HttpPost]
        public TestModel[] GetAllTests()
        {
            TestTable testTable = new TestTable(_dbOptionsTestTable);
            TestModel[] allTests = testTable.GetAllTest();
			return allTests;
        }

        [HttpPost]
        public JsonResult GetAllTestsByIdQuestion(int questionID)
        {
            Console.WriteLine("Id вопрсоа " + questionID);
            TestTable testTable = new TestTable(_dbOptionsTestTable);
            QuestionTable questionTable = new QuestionTable(_dbOptionsQuestionTable);
            TestModel[] allTests = testTable.GetAllTest();
            int idTestQuestion = questionTable.GetTestIDQuestionByQuestionId(questionID);
            Console.WriteLine("ID теста " + idTestQuestion);
            // Создаем объект с двумя свойствами для возврата в JavaScript
            var result = new
            {
                Tests = allTests,
                IdTestQuestion = idTestQuestion
            };

            return Json(result);
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
            Console.WriteLine("userId GetDetailedUserInformation" + userId);
            try
            {
                double[] userResults = new double[4];
                TableAnswerUserTest tableAnswerUserTest = new TableAnswerUserTest(_dbOptionsAnswerUserTest);
                userResults = tableAnswerUserTest.GetRatingsTests(userId);
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
