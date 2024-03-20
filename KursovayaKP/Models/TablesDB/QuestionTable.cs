using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace KursovayaKP.Models.TablesDBModel
{
    public class QuestionTable : DBTables
    {
        public QuestionTable(DbContextOptions<QuestionTable> options) : base(options)
        {
        }

        public bool AddQuestion(QuestionModel question)
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

        public bool DeleteQuestion(int questionId)
        {
            var question = Question.FirstOrDefault(q => q.IdQuestion == questionId);
            if (question != null)
            {
                Question.Remove(question);
                SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateQuestion(QuestionModel question)
        {
            var existingQuestion = Question.Find(question.IdQuestion);
            if (existingQuestion != null)
            {
                existingQuestion.IdTest = question.IdTest;
                existingQuestion.QuestionText = question.QuestionText;
                existingQuestion.Answer1 = question.Answer1;
                existingQuestion.Answer2 = question.Answer2;
                existingQuestion.Answer3 = question.Answer3;
                existingQuestion.Answer4 = question.Answer4;
                existingQuestion.CorrectAnswer = question.CorrectAnswer;
                SaveChanges();
            }
        }

        public QuestionModel[] GetQuestionsTestId(int testId)
        {

            QuestionModel[] questions = Question.Where(q => q.IdTest == testId).ToArray();
            return questions;
        }

        public QuestionModel? GetQuestion(int questionId)
        {
            var question = Question.FirstOrDefault(q => q.IdQuestion == questionId);
            if (question != null)
            {
                return question;
            }
            return null;
        }

        //Получение всех вопросов
        public List<QuestionModel> GetAllQuestions()
        {
            List<QuestionModel> list = Question.ToList();
			return Question.ToList();
		}

        public void DeletingTestQuestions(int testID)
        {
			var questionsToRemove = Question.Where(q => q.IdTest == testID);
			Question.RemoveRange(questionsToRemove);
			SaveChanges();
		}

        public List<QuestionModel> GetRandomQuestionsTest(int testID)
        {
            List<QuestionModel> randomQuestionsTest = Question.Where(q => q.IdTest == testID).OrderBy(t => Guid.NewGuid()).Take(10).ToList();
            return randomQuestionsTest;

		}
	}
}
