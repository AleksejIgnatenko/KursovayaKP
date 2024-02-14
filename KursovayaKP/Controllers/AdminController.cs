using KursovayaKP.Models;
using KursovayaKP.Models.QuestionTableModelDB;
using KursovayaKP.Tables;
using KursovayaKP.Tables.TablesAnswerDB;
using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContextOptions<TableQuestionTrafficRegulations> _dbOptionsTrafficRegulations;
        private readonly DbContextOptions<TableQuestionRoadSigns> _dbOptionsRoadSigns;
        private readonly DbContextOptions<TableQuestionMedicalCare> _dbOptionsMedicalCare;
        private readonly DbContextOptions<TableQuestionCarDevice> _dbOptionsCarDevice;
        private readonly DbContextOptions<TableAnswerUserTest> _dbOptionsAnswerUserTest;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DbContextOptions<TableQuestionTrafficRegulations> dbOptionsTrafficRegulations, DbContextOptions<TableQuestionRoadSigns> dbOptionsRoadSigns, DbContextOptions<TableQuestionMedicalCare> dbOptionsMedicalCare, DbContextOptions<TableQuestionCarDevice> dbOptionsCarDevice, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, ILogger<AdminController> logger)
        {
            _dbOptionsTrafficRegulations = dbOptionsTrafficRegulations;
            _dbOptionsRoadSigns = dbOptionsRoadSigns;
            _dbOptionsMedicalCare = dbOptionsMedicalCare;
            _dbOptionsCarDevice = dbOptionsCarDevice;
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

		//Добавление вопроса ПДД
		[HttpPost]
        public IActionResult Check_AddQuestionTrafficRegulations(QuestionsTrafficRegulationsModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View("AddQuestionTrafficRegulations", questionModel);
                }

                using (var db = new TableQuestionTrafficRegulations(_dbOptionsTrafficRegulations))
                {
                    bool isAdded = db.AddQuestion(questionModel);
                    if (isAdded)
                    {
                        ModelState.Clear(); // Очистить состояние модели
                        return View("~/Views/Admin/AddQuestions/AddQuestionTrafficRegulations.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вопрос с таким текстом уже существует.");
                    }

                    return View("~/Views/Admin/AddQuestions/AddQuestionTrafficRegulations.cshtml");
                }
            }
            return View("AddQuestionTrafficRegulations", questionModel);
        }

        //Добавление вопроса Дорожные знаки
        [HttpPost]
        public IActionResult Check_AddQuestionRoadSigns(QuestionRoadSignsModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View("AddQuestionRoadSigns", questionModel);
                }

                using (var db = new TableQuestionRoadSigns(_dbOptionsRoadSigns))
                {
                    bool isAdded = db.AddQuestion(questionModel);
                    if (isAdded)
                    {
                        ModelState.Clear(); // Очистить состояние модели
                        return View("~/Views/Admin/AddQuestions/AddQuestionRoadSigns.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вопрос с таким текстом уже существует.");
                    }

                    return View("~/Views/Admin/AddQuestions/AddQuestionRoadSigns.cshtml");
                }
            }
            return View("AddQuestionRoadSigns", questionModel);
        }

        //Добавление вопроса Медецинская помощь
        [HttpPost]
        public IActionResult Check_AddQuestionMedicalCare(QuestionMedicalCareModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View("AddQuestionMedicalCare", questionModel);
                }

                using (var db = new TableQuestionMedicalCare(_dbOptionsMedicalCare))
                {
                    bool isAdded = db.AddQuestion(questionModel);
                    if (isAdded)
                    {
                        ModelState.Clear(); // Очистить состояние модели
                        return View("~/Views/Admin/AddQuestions/AddQuestionMedicalCare.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вопрос с таким текстом уже существует.");
                    }

                    return View("~/Views/Admin/AddQuestions/AddQuestionMedicalCare.cshtml");
                }
            }
            return View("AddQuestionMedicalCare", questionModel);
        }

        //Добавление вопроса устройство авто
        [HttpPost]
        public IActionResult Check_AddQuestionCarDevice(QuestionCarDeviceModel questionModel)
        {
            if (ModelState.IsValid)
            {
                var answers = new[] { questionModel.Answer1, questionModel.Answer2, questionModel.Answer3, questionModel.Answer4 };
                var correctAnswer = answers.FirstOrDefault(a => a == questionModel.CorrectAnswer);

                if (correctAnswer == null)
                {
                    ModelState.AddModelError("CorrectAnswer", "Выбранный правильный ответ не найден в списке ответов.");
                    return View("AddQuestionCarDevice", questionModel);
                }

                using (var db = new TableQuestionCarDevice(_dbOptionsCarDevice))
                {
                    bool isAdded = db.AddQuestion(questionModel);
                    if (isAdded)
                    {
                        ModelState.Clear(); // Очистить состояние модели
                        return View("~/Views/Admin/AddQuestions/AddQuestionCarDevice.cshtml");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вопрос с таким текстом уже существует.");
                    }

                    return View("~/Views/Admin/AddQuestions/AddQuestionCarDevice.cshtml");
                }
            }
            return View("AddQuestionCarDevice", questionModel);
        }

    }
}
