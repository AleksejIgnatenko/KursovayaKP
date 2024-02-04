using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
    public class DBQuestion : Tables
    {
        private readonly ILogger<QuestionModel>? _logger;

        public DBQuestion(DbContextOptions<DBQuestion> options) : base(options)
        {
        }

        public bool AddQuestion(QuestionModel question)
        {
            try
            {
                Questions.Add(question);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Обработка исключения, возникшего при работе с базой данных
                // Записываем ошибку в лог
                _logger.LogError(ex, "Ошибка при добавлении вопроса в базу данных");
                return false;
            }
        }
    }
}
