using KursovayaKP.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace KursovayaKP.Models.TablesDBModel
{
    public class TableAnswerUserTest : DBTables
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

        /*        public double GetRatingsTest(int userId, string nameTest)
                {
                    int[] results = AnswerUserTest.Where(a => a.UserId == userId && a.NameTest == nameTest).Select(a => a.ResultTest).ToArray();
                    if (results.Length != 0)
                    {
                        double summ = results.Sum();
                        double result = summ / results.Length;
                        result = Math.Round(result, 2);
                        return result;
                        //List<AnswerUserTestModel> result = AnswerUserTest.Where(a => a.UserId == userId && a.NameTest == nameTest).ToList();
                    }
                    return -1;
                }*/

        public Dictionary<int, int[]> GetRatingsTests(int userID)
        {
            Dictionary<int, int[]> ratings = new Dictionary<int, int[]>();
            for (int i = 1; i < 8; i++)
            {
                int[] test = AnswerUserTest.Where(a => Tests.Any(t => t.IdTest == a.TestId && t.IdCategory == i)).Where(u => u.UserId == userID)
                                            .Select(a => a.ResultTest)
                                            .Take(5).ToArray();

                ratings.Add(i, test);
            }
            foreach (var r in ratings)
            {
                Console.WriteLine($"Ключ: {r.Key}, Значение: {r.Value}");
            }
            return ratings;
        }

        public string ExamIsPassed(int userID, int catigoryID)
        {
            //int lastResult = AnswerUserTest.Where((u => u.UserId == userID) && (c => c )).FirstOrDefault();
            int lastResult = AnswerUserTest.Where(a => Tests.Any(t => t.IdTest == a.TestId && t.IdCategory == catigoryID))
                                           .Where(u => u.UserId == userID)
                                           .Select(a => a.ResultTest)
                                           .OrderByDescending(result => result)
                                           .FirstOrDefault();
            if (lastResult > 8)
            {
                return "Экзамен сдан";
            }
            return "Экзамен не сдан";
        }

    }
}
