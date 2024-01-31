using KursovayaKP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KursovayaKP.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Sign_In()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

		//Вход в аккаунт
		[HttpPost]
        public IActionResult Check_Sign_In(UserModel userModel)
        {
/*            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }*/
            return View("Sign_In");
        }

        //Регистрация
        [HttpPost]
        public IActionResult Check_registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // Add cookies
                Response.Cookies.Append("UserName", userModel.UserName);
                Response.Cookies.Append("Email", userModel.Email);
                Response.Cookies.Append("Role", userModel.Role);

                return RedirectToAction("Index", "Home");
            }

            // Валидация не удалась, возвращаем модель с ошибками
            return View("Registration", userModel);
        }
    }
}
