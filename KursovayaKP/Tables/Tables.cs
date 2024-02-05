using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
    public class Tables : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionsTrafficRegulationsModel> QuestionsTrafficRegulations { get; set; }



        // Создаем базу данных при первом обращении
        public Tables(DbContextOptions<DBUser> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Создаем базу данных при первом обращении
        public Tables(DbContextOptions<TableQuestionTrafficRegulations> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
