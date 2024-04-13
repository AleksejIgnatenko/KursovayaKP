using KursovayaKP.Controllers;
using KursovayaKP.Models;
using KursovayaKP.Models.TablesDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class DBTables : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Question { get; set; }
        public DbSet<AnswerUserTestModel> AnswerUserTest { get; set; }
        public DbSet<TestModel> Tests { get; set; }
		public DbSet<CategoryModel> Category { get; set; }


		// Создаем базу данных при первом обращении
		public DBTables(DbContextOptions<UserTable> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public DBTables(DbContextOptions<QuestionTable> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public DBTables(DbContextOptions<TableAnswerUserTest> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public DBTables(DbContextOptions<TestTable> options) : base(options)
        {
            Database.EnsureCreated();
        }

		// Создаем базу данных при первом обращении
		public DBTables(DbContextOptions<CategoryTable> options) : base(options)
		{
			Database.EnsureCreated();
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Добавление записей в таблицу Users
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { IdUser = 1, UserName = "Алексей", Email = "ignatenkoaleksej771@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "Manager" },
                new UserModel { IdUser = 2, UserName = "Bob", Email = "test@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" },
                new UserModel { IdUser = 3, UserName = "Sam", Email = "test1@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" }
            );

            //Добавление записей в таблицу CategoryModel
            modelBuilder.Entity<CategoryModel>().HasData(
                    new CategoryModel { IdCategory = 1, NameCategory = "ПДД" },
					new CategoryModel { IdCategory = 2, NameCategory = "Дорожные светофоры" },
					new CategoryModel { IdCategory = 3, NameCategory = "Дорожные знаки" },
					new CategoryModel { IdCategory = 4, NameCategory = "Дорожная разметка" },
					new CategoryModel { IdCategory = 5, NameCategory = "Неисправности" },
					new CategoryModel { IdCategory = 6, NameCategory = "Опознавательные знаки" },
					new CategoryModel { IdCategory = 7, NameCategory = "Медецинская помощь" }
			);

            //Добавление записей в таблицу Test
            modelBuilder.Entity<TestModel>().HasData(
                    new TestModel { IdTest = 1, IdCategory = 1, NameTest = "Тест 1" },
                    new TestModel { IdTest = 2, IdCategory = 2, NameTest = "Тест 2" },
                    new TestModel { IdTest = 3, IdCategory = 3, NameTest = "Тест 3" },
                    new TestModel { IdTest = 4, IdCategory = 4, NameTest = "Тест 4" },
					new TestModel { IdTest = 5, IdCategory = 5, NameTest = "Тест 4" },
					new TestModel { IdTest = 6, IdCategory = 6, NameTest = "Тест 4" },
					new TestModel { IdTest = 7, IdCategory = 7, NameTest = "Тест 4" }

			);

            //Добавление записей в таблицу Quenstion
            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel { IdQuestion = 1, IdTest = 1, QuestionText = "Вопрос Пдд", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 2, IdTest = 2, QuestionText = "Вопрос Дорожные светофоры", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 3, IdTest = 3, QuestionText = "Вопрос Дорожные знаки", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 4, IdTest = 4, QuestionText = "Вопрос Дорожная разметка", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 5, IdTest = 5, QuestionText = "Вопрос Неисправности", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 6, IdTest = 6, QuestionText = "Вопрос Опознавательные знаки", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 7, IdTest = 7, QuestionText = "Вопрос Медецинская помощь", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
                
/*                new QuestionModel { IdQuestion = 8, IdTest = 2, QuestionText = "Вопрос 8", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 9, IdTest = 3, QuestionText = "Вопрос 9", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 10, IdTest = 3, QuestionText = "Вопрос 10", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 11, IdTest = 3, QuestionText = "Вопрос 11", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 12, IdTest = 3, QuestionText = "Вопрос 12", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 13, IdTest = 4, QuestionText = "Вопрос 13", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 14, IdTest = 4, QuestionText = "Вопрос 14", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 15, IdTest = 4, QuestionText = "Вопрос 15", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },

                new QuestionModel { IdQuestion = 16, IdTest = 4, QuestionText = "Вопрос 16", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }*/

/*                new QuestionModel { IdQuestion = 17, QuestionText = "Вопрос 17", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 18, QuestionText = "Вопрос 18", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 19, QuestionText = "Вопрос 19", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 20, QuestionText = "Вопрос 20", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 21, QuestionText = "Вопрос 21", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 22, QuestionText = "Вопрос 22", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 23, QuestionText = "Вопрос 23", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 24, QuestionText = "Вопрос 24", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 25, QuestionText = "Вопрос 25", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 26, QuestionText = "Вопрос 26", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 27, QuestionText = "Вопрос 27", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 28, QuestionText = "Вопрос 28", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 29, QuestionText = "Вопрос 29", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 30, QuestionText = "Вопрос 30", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },

                new QuestionModel { IdQuestion = 31, QuestionText = "Вопрос 31", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 32, QuestionText = "Вопрос 32", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 33, QuestionText = "Вопрос 33", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 34, QuestionText = "Вопрос 34", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 35, QuestionText = "Вопрос 35", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 36, QuestionText = "Вопрос 36", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 37, QuestionText = "Вопрос 37", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 38, QuestionText = "Вопрос 38", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 39, QuestionText = "Вопрос 39", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 40, QuestionText = "Вопрос 40", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 41, QuestionText = "Вопрос 41", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 42, QuestionText = "Вопрос 42", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 43, QuestionText = "Вопрос 43", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 44, QuestionText = "Вопрос 44", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 45, QuestionText = "Вопрос 45", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },

                new QuestionModel { IdQuestion = 46, QuestionText = "Вопрос 46", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 47, QuestionText = "Вопрос 47", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 48, QuestionText = "Вопрос 48", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 49, QuestionText = "Вопрос 49", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 50, QuestionText = "Вопрос 50", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 51, QuestionText = "Вопрос 51", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 52, QuestionText = "Вопрос 52", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 53, QuestionText = "Вопрос 53", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 54, QuestionText = "Вопрос 54", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 55, QuestionText = "Вопрос 55", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 56, QuestionText = "Вопрос 56", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 57, QuestionText = "Вопрос 57", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 58, QuestionText = "Вопрос 58", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 59, QuestionText = "Вопрос 59", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionModel { IdQuestion = 60, QuestionText = "Вопрос 60", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }*/
            );
        }
    }
}
