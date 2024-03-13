using KursovayaKP.Models.TablesDBModel;
using Microsoft.EntityFrameworkCore;

namespace KursovayaKP.Models.TablesDB
{
	public class CategoryTable : DBTables
	{
		public CategoryTable(DbContextOptions<CategoryTable> options) : base(options)
		{
		}

		public CategoryModel[] GetAllCategory()
		{
			return Category.ToArray();
		}

    }
}
