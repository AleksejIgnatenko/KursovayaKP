using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDBModel
{
    public class QuestionTable : TablesDB
    {
        private readonly ILogger<QuestionTable>? _logger;
        public QuestionTable(DbContextOptions<QuestionTable> options) : base(options)
        {
        }

        public bool AddQuestion(QuestionModel question)
        {
            try
            {
                // Проверяем наличие пользователя с такой же почтой
                var existingquestion = Question.FirstOrDefault(q => q.QuestionText == question.QuestionText);
                if (existingquestion != null)
                {
                    return false;
                }

                Question.Add(question);
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

        public bool DeleteQuestion(int questionId)
        {
            var question = Question.FirstOrDefault(q => q.Id == questionId);
            if (question != null)
            {
                Question.Remove(question);
                SaveChanges();
                return true;
            }
            return false;
        }

        //Получение всех вопросов
        public List<QuestionModel> GetAllQuestions()
        {
            return Question.ToList();

        }
    }
}
