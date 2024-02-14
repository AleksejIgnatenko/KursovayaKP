using KursovayaKP.Tables.TablesAnswerDB;
using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables
{
    public class TableAnswerUserTest : TablesDB
    {
        private readonly ILogger<TableAnswerUserTest>? _logger;
        public TableAnswerUserTest(DbContextOptions<TableAnswerUserTest> options) : base(options)
        {

        }
    }
}
