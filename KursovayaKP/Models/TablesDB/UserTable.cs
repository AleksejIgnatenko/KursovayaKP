using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class UserTable : TablesDB
    {
        private readonly ILogger<UserModel>? _logger;

        public UserTable(DbContextOptions<UserTable> options) : base(options)
        {
        }

        //Получение всех пользователей
        public List<UserModel> GetAllUsers()
        {
            return Users.ToList();
        }

        // Добавление пользователя
        public bool AddUser(UserModel user)
        {
            try
            {
                // Проверяем наличие пользователя с такой же почтой
                var existingUser = Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    // Пользователь с такой почтой уже существует
                    return false;
                }

                Users.Add(user);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Обработка исключения, возникшего при работе с базой данных
                // Записываем ошибку в лог
                _logger.LogError(ex, "Ошибка при добавлении пользователя в базу данных");
                return false;
            }
        }

        public UserModel? GetUser(int id)
        {
            UserModel? user = Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
