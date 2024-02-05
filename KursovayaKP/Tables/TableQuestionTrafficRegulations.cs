using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
    public class TableQuestionTrafficRegulations : Tables
    {
        private readonly ILogger<TableQuestionTrafficRegulations>? _logger;
        public TableQuestionTrafficRegulations(DbContextOptions<TableQuestionTrafficRegulations> options) : base(options)
        {

        }

        public bool AddQuestion(QuestionsTrafficRegulationsModel question)
        {
            try
            {
                QuestionsTrafficRegulations.Add(question);
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
