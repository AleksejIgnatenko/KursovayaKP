using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
	public class DBUser : Tables
	{
		private readonly ILogger<UserModel>? _logger;

        public DBUser(DbContextOptions<DBUser> options) : base(options)
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

		//Заполнение таблицыпри при создании
		/*		protected override void OnModelCreating(ModelBuilder modelBuilder)
				{
					modelBuilder.Entity<UserModel>().HasData(
						new UserModel { UserName = "Tom", Email = "Login1", Password = "1" },
						new UserModel { UserName = "Bob", Email = "Login2", Password = "2" },
						new UserModel { UserName = "Sam", Email = "Login3", Password = "3" }
					);
				}*/
	}
}
