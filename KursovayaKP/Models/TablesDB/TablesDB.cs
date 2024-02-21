using KursovayaKP.Controllers;
using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class TablesDB : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Question { get; set; }
        public DbSet<AnswerUserTestModel> AnswerUserTest { get; set; }



        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<UserTable> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<QuestionTable> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<TableAnswerUserTest> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Добавление записей в таблицу Users
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, UserName = "Алексей", Email = "ignatenkoaleksej771@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "Admin" },
                new UserModel { Id = 2, UserName = "Bob", Email = "test@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" },
                new UserModel { Id = 3, UserName = "Sam", Email = "test1@gmail.com", Password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Repeat_password = "+lhdichR3TOKcNz1Naoqkv7ng23Wr/EiZYPojgmWKT8WvACcZSgm4PxccGaVoDzdzjcvE57/TROVnabx9dPqvg==", Role = "User" }
            );

            //Добавление записей в таблицу Quenstion
            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel { Id = 1, QuestionText = "Вопрос 1", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 2, QuestionText = "Вопрос 2", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 3, QuestionText = "Вопрос 3", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 4, QuestionText = "Вопрос 4", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 5, QuestionText = "Вопрос 5", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 6, QuestionText = "Вопрос 6", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 7, QuestionText = "Вопрос 7", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 8, QuestionText = "Вопрос 8", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 9, QuestionText = "Вопрос 9", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 10, QuestionText = "Вопрос 10", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 11, QuestionText = "Вопрос 11", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 12, QuestionText = "Вопрос 12", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 13, QuestionText = "Вопрос 13", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 14, QuestionText = "Вопрос 14", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },
                new QuestionModel { Id = 15, QuestionText = "Вопрос 15", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.TrafficRegulations.ToString() },

                new QuestionModel { Id = 16, QuestionText = "Вопрос 16", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 17, QuestionText = "Вопрос 17", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 18, QuestionText = "Вопрос 18", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 19, QuestionText = "Вопрос 19", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 20, QuestionText = "Вопрос 20", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 21, QuestionText = "Вопрос 21", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 22, QuestionText = "Вопрос 22", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 23, QuestionText = "Вопрос 23", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 24, QuestionText = "Вопрос 24", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 25, QuestionText = "Вопрос 25", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 26, QuestionText = "Вопрос 26", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 27, QuestionText = "Вопрос 27", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 28, QuestionText = "Вопрос 28", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 29, QuestionText = "Вопрос 29", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },
                new QuestionModel { Id = 30, QuestionText = "Вопрос 30", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.RoadSigns.ToString() },

                new QuestionModel { Id = 31, QuestionText = "Вопрос 31", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 32, QuestionText = "Вопрос 32", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 33, QuestionText = "Вопрос 33", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 34, QuestionText = "Вопрос 34", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 35, QuestionText = "Вопрос 35", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 36, QuestionText = "Вопрос 36", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 37, QuestionText = "Вопрос 37", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 38, QuestionText = "Вопрос 38", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 39, QuestionText = "Вопрос 39", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 40, QuestionText = "Вопрос 40", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 41, QuestionText = "Вопрос 41", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 42, QuestionText = "Вопрос 42", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 43, QuestionText = "Вопрос 43", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 44, QuestionText = "Вопрос 44", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },
                new QuestionModel { Id = 45, QuestionText = "Вопрос 45", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.MedicalCare.ToString() },

                new QuestionModel { Id = 46, QuestionText = "Вопрос 46", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 47, QuestionText = "Вопрос 47", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 48, QuestionText = "Вопрос 48", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 49, QuestionText = "Вопрос 49", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 50, QuestionText = "Вопрос 50", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 51, QuestionText = "Вопрос 51", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 52, QuestionText = "Вопрос 52", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 53, QuestionText = "Вопрос 53", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 54, QuestionText = "Вопрос 54", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 55, QuestionText = "Вопрос 55", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 56, QuestionText = "Вопрос 56", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 57, QuestionText = "Вопрос 57", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 58, QuestionText = "Вопрос 58", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 59, QuestionText = "Вопрос 59", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() },
                new QuestionModel { Id = 60, QuestionText = "Вопрос 60", Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4", Topic = QuestionModel.Section.CarDevice.ToString() }
            );
        }
    }
}
