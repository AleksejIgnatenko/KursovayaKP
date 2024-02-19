using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class TableAnswerUserTest : TablesDB
    {
        private readonly ILogger<TableAnswerUserTest>? _logger;
        public TableAnswerUserTest(DbContextOptions<TableAnswerUserTest> options) : base(options)
        {
        }

        public bool AddAnswer(AnswerUserTestModel answer)
        {
            try
            {
                AnswerUserTest.Add(answer);
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
