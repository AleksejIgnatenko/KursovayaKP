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
		
		public CategoryModel? GetCategory(int id)
		{
			CategoryModel? category = Category.FirstOrDefault(category => category.IdCategory == id);
			return category;
		}

		public string? GetNameCategory(int id)
		{
			string? nameCategory = Category.Where(c => c.IdCategory == id).Select(c => c.NameCategory).FirstOrDefault();
			Console.WriteLine("название категории: " + nameCategory);
            return nameCategory;
        }
    }
}
