using KursovayaKP.Models;
using KursovayaKP.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContextOptions<DBQuestion> _dbOptions;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DbContextOptions<DBQuestion> dbOptions, ILogger<AdminController> logger)
        {
            _dbOptions = dbOptions;
            _logger = logger;
        }

        public IActionResult TestAdmin()
        {
            return View();
        }

        public IActionResult AddQuestionTrafficRegulations()
        {
            return View();
        }

        //Добавление вопроса
        [HttpPost]
        public IActionResult Check_AddQuestionTrafficRegulations(QuestionModel questionModel)
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

                using (var db = new DBQuestion(_dbOptions))
                {
                    bool isAdded = db.AddQuestion(questionModel);
                    if (isAdded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вопрос с таким текстом уже существует.");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View("AddQuestionTrafficRegulations", questionModel);
        }
    }
}
