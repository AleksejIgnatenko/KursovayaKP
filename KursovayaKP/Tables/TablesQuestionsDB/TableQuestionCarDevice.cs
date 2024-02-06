using KursovayaKP.Models.QuestionTableModelDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables.TablesQuestionsDB
{
    public class TableQuestionCarDevice : TablesDB
    {
        private readonly ILogger<TableQuestionCarDevice>? _logger;
        public TableQuestionCarDevice(DbContextOptions<TableQuestionCarDevice> options) : base(options)
        {

        }

        public bool AddQuestion(QuestionCarDeviceModel question)
        {
            try
            {
                QuestionCarDevice.Add(question);
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
