using KursovayaKP.Models;
using KursovayaKP.Models.QuestionTableModelDB;
using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
    public class TablesDB : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionsTrafficRegulationsModel> QuestionsTrafficRegulations { get; set; }
        public DbSet<QuestionRoadSignsModel> QuestionRoadSigns { get; set; }
        public DbSet<QuestionMedicalCareModel> QuestionMedicalCare { get; set; }
        public DbSet<QuestionCarDeviceModel> QuestionCarDevice { get; set; }
        public DbSet<AnswerUserTestModel> AnswerUserTest { get; set; }



        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<DBUser> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<TableQuestionTrafficRegulations> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<TableQuestionRoadSigns> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<TableQuestionMedicalCare> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public TablesDB(DbContextOptions<TableQuestionCarDevice> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*        // Создаем базу данных при первом обращении
                public TablesDB(DbContextOptions<TableAnswerUserTestTrafficRegulations> options) : base(options)
                {
                    Database.EnsureCreated();
                }*/

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

            //Добавление вопросов в таблицу QuestionsTrafficRegulations
            modelBuilder.Entity<QuestionsTrafficRegulationsModel>().HasData(
                new QuestionsTrafficRegulationsModel { Id = 1, QuestionText = "Вопрос 1", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 2, QuestionText = "Вопрос 2", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 3, QuestionText = "Вопрос 3", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 4, QuestionText = "Вопрос 4", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 5, QuestionText = "Вопрос 5", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 6, QuestionText = "Вопрос 6", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 7, QuestionText = "Вопрос 7", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 8, QuestionText = "Вопрос 8", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 9, QuestionText = "Вопрос 9", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 10, QuestionText = "Вопрос 10", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 11, QuestionText = "Вопрос 11", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 12, QuestionText = "Вопрос 12", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 13, QuestionText = "Вопрос 13", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 14, QuestionText = "Вопрос 14", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 15, QuestionText = "Вопрос 15", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
            );

            //Добавление вопросов в таблицу QuestionRoadSignsModel
            modelBuilder.Entity<QuestionRoadSignsModel>().HasData(
                new QuestionRoadSignsModel { Id = 1, QuestionText = "Вопрос 1", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 2, QuestionText = "Вопрос 2", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 3, QuestionText = "Вопрос 3", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 4, QuestionText = "Вопрос 4", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 5, QuestionText = "Вопрос 5", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 6, QuestionText = "Вопрос 6", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 7, QuestionText = "Вопрос 7", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 8, QuestionText = "Вопрос 8", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 9, QuestionText = "Вопрос 9", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 10, QuestionText = "Вопрос 10", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 11, QuestionText = "Вопрос 11", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 12, QuestionText = "Вопрос 12", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 13, QuestionText = "Вопрос 13", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 14, QuestionText = "Вопрос 14", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionRoadSignsModel { Id = 15, QuestionText = "Вопрос 15", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
            );

            //Добавление вопросов в таблицу QuestionMedicalCareModel
            modelBuilder.Entity<QuestionMedicalCareModel>().HasData(
                new QuestionMedicalCareModel { Id = 1, QuestionText = "Вопрос 1", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 2, QuestionText = "Вопрос 2", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 3, QuestionText = "Вопрос 3", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 4, QuestionText = "Вопрос 4", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 5, QuestionText = "Вопрос 5", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 6, QuestionText = "Вопрос 6", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 7, QuestionText = "Вопрос 7", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 8, QuestionText = "Вопрос 8", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 9, QuestionText = "Вопрос 9", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 10, QuestionText = "Вопрос 10", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 11, QuestionText = "Вопрос 11", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 12, QuestionText = "Вопрос 12", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 13, QuestionText = "Вопрос 13", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 14, QuestionText = "Вопрос 14", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionMedicalCareModel { Id = 15, QuestionText = "Вопрос 15", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
            );

            //Добавление вопросов в таблицу QuestionCarDeviceModel
            modelBuilder.Entity<QuestionCarDeviceModel>().HasData(
                new QuestionCarDeviceModel { Id = 1, QuestionText = "Вопрос 1", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 2, QuestionText = "Вопрос 2", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 3, QuestionText = "Вопрос 3", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 4, QuestionText = "Вопрос 4", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 5, QuestionText = "Вопрос 5", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 6, QuestionText = "Вопрос 6", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 7, QuestionText = "Вопрос 7", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 8, QuestionText = "Вопрос 8", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 9, QuestionText = "Вопрос 9", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 10, QuestionText = "Вопрос 10", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 11, QuestionText = "Вопрос 11", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 12, QuestionText = "Вопрос 12", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 13, QuestionText = "Вопрос 13", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 14, QuestionText = "Вопрос 14", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionCarDeviceModel { Id = 15, QuestionText = "Вопрос 15", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
            );
        }
    }
}
