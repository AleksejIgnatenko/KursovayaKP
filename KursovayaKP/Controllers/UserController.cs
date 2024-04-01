using KursovayaKP.Models;
using KursovayaKP.Models.TablesDB;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KursovayaKP.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContextOptions<QuestionTable> _dbOptionsQuestionTable;
        private readonly DbContextOptions<TableAnswerUserTest> _dbOptionsAnswerUserTest;
        private readonly DbContextOptions<UserTable> _dbOptionsUserTable;
        private readonly DbContextOptions<TestTable> _dbOptionsTestTable;
        private readonly DbContextOptions<CategoryTable> _dbOptionsCategoryTable;
        private readonly ILogger<AdminController> _logger;

        public UserController(DbContextOptions<QuestionTable> dbOptionsQuestionTable, DbContextOptions<TableAnswerUserTest> dbOptionsAnswerUserTest, DbContextOptions<UserTable> dbOptionsUserTable, DbContextOptions<TestTable> dbOptionsTestTable, DbContextOptions<CategoryTable> dbOptionsCategoryTable, ILogger<AdminController> logger)
        {
            _dbOptionsQuestionTable = dbOptionsQuestionTable;
            _dbOptionsAnswerUserTest = dbOptionsAnswerUserTest;
            _dbOptionsUserTable = dbOptionsUserTable;
            _dbOptionsTestTable = dbOptionsTestTable;
            _dbOptionsCategoryTable = dbOptionsCategoryTable;
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
            try
            {
                // Получение значения 'id' из куки
                string? idCookie = Request.Cookies["ID"];

                if (string.IsNullOrEmpty(idCookie) || !int.TryParse(idCookie, out int outId))
                {
                    // Если 'id' отсутствует или недопустим, установить код состояния 404 и вернуть ошибку
                    return NotFound();
                }

                int id = Convert.ToInt32(idCookie);

                TableAnswerUserTest tableAnswerUserTest = new TableAnswerUserTest(_dbOptionsAnswerUserTest);
                CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
                UserTable userTable = new UserTable(_dbOptionsUserTable);
                UserModel? user = userTable.GetUser(id);

                if (user != null)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        string? nameCategory = categoryTable.GetNameCategory(i);
                        string resultExam = tableAnswerUserTest.ExamIsPassed(id, i);
                        ViewBag.Result += nameCategory + ": " + resultExam + "<br />";
                    }
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
            }

			return View();
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
                    using (var db = new UserTable(_dbOptionsUserTable)) // Создаем экземпляр DBUser
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
					_logger.LogError($"{ex}");
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
                using (var db = new UserTable(_dbOptionsUserTable))
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
				ModelState.AddModelError("Password", "Ошибка получения данных");
				_logger.LogError($"{ex}");
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

        public IActionResult EditUserName(int id, string newUserName)
        {
            Console.WriteLine(id);
            Console.WriteLine(newUserName);
            try
            {
                UserTable userTable = new UserTable(_dbOptionsUserTable);
                userTable.EditUserName(id, newUserName);
         

                TableAnswerUserTest tableAnswerUserTest = new TableAnswerUserTest(_dbOptionsAnswerUserTest);
                CategoryTable categoryTable = new CategoryTable(_dbOptionsCategoryTable);
                UserModel? user = userTable.GetUser(id);

                if (user != null)
                {
                    Console.WriteLine(user.Email);
                    for (int i = 1; i < 5; i++)
                    {
                        string? nameCategory = categoryTable.GetNameCategory(i);
                        string resultExam = tableAnswerUserTest.ExamIsPassed(id, i);
                        ViewBag.Result += nameCategory + ": " + resultExam + "<br />";
                    }
                    return View("~/Views/User/Personal_office.cshtml", user);
                }
                return View("~/Views/User/Personal_office.cshtml");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка изменения имени пользователя");
            }
            return View("~/Views/User/Personal_office.cshtml");
        }
    }
}
