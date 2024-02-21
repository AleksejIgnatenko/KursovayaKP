using KursovayaKP.Models;
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
        private readonly ILogger<AdminController> _logger;

        public AdminController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
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
