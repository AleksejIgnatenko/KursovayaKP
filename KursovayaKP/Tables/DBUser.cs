using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
	public class DBUser : DbContext
	{
		public DbSet<UserModel> Users { get; set; }

		// Создаем базу данных при первом обращении
		public DBUser(DbContextOptions<DBUser> options) : base(options)
		{
			Database.EnsureCreated();   
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
