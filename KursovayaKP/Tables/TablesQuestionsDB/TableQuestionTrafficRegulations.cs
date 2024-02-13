using KursovayaKP.Models;
using KursovayaKP.Models.QuestionTableModelDB;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Tables.TablesQuestionsDB
{
    public class TableQuestionTrafficRegulations : TablesDB
    {
        private readonly ILogger<TableQuestionTrafficRegulations>? _logger;
        public TableQuestionTrafficRegulations(DbContextOptions<TableQuestionTrafficRegulations> options) : base(options)
        {
        }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Populate the Users table with data
            modelBuilder.Entity<QuestionsTrafficRegulationsModel>().HasData(
                new QuestionsTrafficRegulationsModel { Id = 1, QuestionText = "Вопрос 1", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 2, QuestionText = "Вопрос 2", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 3, QuestionText = "Вопрос 3", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 4, QuestionText = "Вопрос 4", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 5, QuestionText = "Вопрос 5", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 6, QuestionText = "Вопрос 6", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 7, QuestionText = "Вопрос 7", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 8, QuestionText = "Вопрос 8", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 9, QuestionText = "Вопрос 9", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 10, QuestionText = "Вопрос 10", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 11, QuestionText = "Вопрос 11", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 12, QuestionText = "Вопрос 12", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 13, QuestionText = "Вопрос 13", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 14, QuestionText = "Вопрос 14", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" },
                new QuestionsTrafficRegulationsModel { Id = 15, QuestionText = "Вопрос 15", LinkPhoto = null, Answer1 = "1", Answer2 = "2", Answer3 = "3", Answer4 = "4", CorrectAnswer = "4" }
            );
        }*/

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

        //Получение всех вопросов
        public List<QuestionsTrafficRegulationsModel> GetAllQuestionsTrafficRegulations()
        {
            return QuestionsTrafficRegulations.ToList();

        }
    }
}
