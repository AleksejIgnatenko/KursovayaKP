using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class UserTable : DBTables
    {

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

        public UserModel? GetUser(int id)
        {
            UserModel? user = Users.FirstOrDefault(u => u.IdUser == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
