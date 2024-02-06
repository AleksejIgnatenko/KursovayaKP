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
    }
}
