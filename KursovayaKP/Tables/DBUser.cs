using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
	public class DBUser : TablesDB
	{
		private readonly ILogger<UserModel>? _logger;

        public DBUser(DbContextOptions<DBUser> options) : base(options)
        {
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Populate the Users table with data
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, UserName = "Алексей", Email = "ignatenkoaleksej771@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "Admin" },
                new UserModel { Id = 2, UserName = "Bob", Email = "test@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" },
                new UserModel { Id = 3, UserName = "Sam", Email = "test1@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" }
            );
        }*/


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
    }
}
