using KursovayaKP.Models.QuestionTableModelDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables.TablesQuestionsDB
{
    public class TableQuestionMedicalCare : TablesDB
    {
        private readonly ILogger<TableQuestionMedicalCare>? _logger;
        public TableQuestionMedicalCare(DbContextOptions<TableQuestionMedicalCare> options) : base(options)
        {

        }

        public bool AddQuestion(QuestionMedicalCareModel question)
        {
            try
            {
                QuestionMedicalCare.Add(question);
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
