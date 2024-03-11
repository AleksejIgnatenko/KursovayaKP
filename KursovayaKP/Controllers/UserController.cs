using KursovayaKP.Models;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KursovayaKP.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextOptions<UserTable> _dbOptionsUser;
        private readonly ILogger<UserController> _logger;

        public UserController(DbContextOptions<UserTable> dbOptionsUser, ILogger<UserController> logger)
        {
            _dbOptionsUser = dbOptionsUser;
            _logger = logger;
        }

        public IActionResult Sign_In()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Personal_office()
        {
            // Получение значения 'id' из куки
            string idCookie = Request.Cookies["Id"];

            if (string.IsNullOrEmpty(idCookie) || !int.TryParse(idCookie, out int outId))
            {
                // Если 'id' отсутствует или недопустим, установить код состояния 404 и вернуть ошибку
                return NotFound();
            }

            int id = Convert.ToInt32(idCookie);
            Console.WriteLine(id);
            UserTable userTable = new UserTable(_dbOptionsUser);
            UserModel user = userTable.GetUser(id);

            return View(user);
        }

        //Регистрация
        [HttpPost]
        public IActionResult Check_registration(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Password = UserModel.HashPassword(userModel.Password);


                try
                {
                    using (var db = new UserTable(_dbOptionsUser)) // Создаем экземпляр DBUser
                    {
                        bool userAdded = db.AddUser(userModel); // Добавляем пользователя в базу данных

                        if (userAdded)
                        {
                            // Add cookies
                            Response.Cookies.Append("ID", userModel.IdUser.ToString());
                            Response.Cookies.Append("UserName", userModel.UserName);
                            Response.Cookies.Append("Role", userModel.Role);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            // Пользователь с такой почтой уже существует
                            ModelState.AddModelError("Email", "Аккаунт с таким Email уже существует");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка Регистрации(не получилоась зарегистрировать)");
                }
            }

            // Валидация не удалась или пользователь с такой почтой уже существует, возвращаем модель с ошибками
            return View("Registration", userModel);
        }

        //Вход в аккаунт
        [HttpPost]
        public IActionResult Check_Sign_In(UserModel userModel)
        {
            // Проверяем наличие пользователя с введенным email и паролем
            try
            {
                using (var db = new UserTable(_dbOptionsUser))
                {
                    var user = db.Users.FirstOrDefault(u => u.Email == userModel.Email && u.Password == UserModel.HashPassword(userModel.Password));
                    if (user != null)
                    {
                        // Данные пользователя совпадают, устанавливаем куки и выполняем перенаправление
                        Response.Cookies.Append("ID", user.IdUser.ToString());
                        Response.Cookies.Append("UserName", user.UserName);
                        Response.Cookies.Append("Role", user.Role);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Данные пользователя не совпадают или пользователь не найден
                        ModelState.AddModelError("Password", "Неверный Email или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения, возникшего при работе с базой данных
                _logger.LogError(ex, "Ошибка входа в аккаунт(не получилось войти");
            }

            // Валидация не удалась или данные пользователя не совпадают, возвращаем модель с ошибками
            return View("Sign_In", userModel);
        }

        //Выход из аккаунта
        public IActionResult Exit_in_account()
        {
            Response.Cookies.Delete("ID");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("Role");

            return RedirectToAction("Index", "Home");
        }

    }
}
