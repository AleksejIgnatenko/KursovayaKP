using KursovayaKP.Models.QuestionTableModelDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables.TablesQuestionsDB
{
    public class TableQuestionRoadSigns : TablesDB
    {
        private readonly ILogger<TableQuestionRoadSigns>? _logger;
        public TableQuestionRoadSigns(DbContextOptions<TableQuestionRoadSigns> options) : base(options)
        {

        }

        public bool AddQuestion(QuestionRoadSignsModel question)
        {
            try
            {
                QuestionRoadSigns.Add(question);
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
