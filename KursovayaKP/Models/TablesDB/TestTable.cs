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
    }
}
