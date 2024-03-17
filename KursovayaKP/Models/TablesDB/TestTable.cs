using KursovayaKP.Models.TablesDBModel;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDB
{
    public class TestTable : DBTables
    {
        public TestTable(DbContextOptions<TestTable> options) : base(options)
        {
        }

        public void AddTest(TestModel testModel) 
        {
            Tests.Add(testModel);
            SaveChanges();
        }

        public TestModel[] GetAllTest()
        {
            return Tests.ToArray();
        }

        public string? GetNameTest(int idTest) 
        {
            return Tests.Where(t => t.IdTest == idTest).Select(t => t.NameTest).FirstOrDefault();
        }

		public bool DeleteTest(int idTest)
		{
			TestModel? test = Tests.FirstOrDefault(t => t.IdTest == idTest);
			if (test != null)
			{
				Tests.Remove(test);
				SaveChanges();
				return true;
			}
			return false;
		}

		public TestModel? GetTest(int idTest)
		{
			TestModel? test = Tests.FirstOrDefault(t => t.IdTest == idTest);
			if (test != null)
			{
				return test;
			}
			return null;
		}

	}
}
