using KursovayaKP.Models;
using Microsoft.AspNetCore.Mvc;

namespace KursovayaKP.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult TestAdmin()
        {
            return View();
        }

        public IActionResult AddQuestionTrafficRegulations()
        {
            return View();
        }

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

                return RedirectToAction("Index", "Home");
            }

            return View("AddQuestionTrafficRegulations", questionModel);
        }
    }
}
