using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables.TablesAnswerDB
{
    public class TableAnswerUserTestTrafficRegulations : TablesDB
    {
        private readonly ILogger<TableQuestionCarDevice>? _logger;
        public TableAnswerUserTestTrafficRegulations(DbContextOptions<TableAnswerUserTestTrafficRegulations> options) : base(options)
        {

        }
    }
}
