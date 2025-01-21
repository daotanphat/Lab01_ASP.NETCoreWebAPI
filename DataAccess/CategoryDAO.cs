using BusinessObject;
using BusinessObjects;

namespace DataAccess
{
	public class CategoryDAO
	{
		public static List<Category> GetCategories()
		{
			var categories = new List<Category>();
			try
			{
				using (var context = new MyDbContext())
				{
					categories = context.Category.ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return categories;
		}
	}
}
