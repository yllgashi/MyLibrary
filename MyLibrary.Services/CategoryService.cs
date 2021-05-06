using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class CategoryService
    {
        CategoryAccess categoryAccess;

        public CategoryService()
        {
            categoryAccess = new CategoryAccess();
        }

        public List<Category> GetList()
        {
            return categoryAccess.GetAll();
        }

        public Category Get (int id)
        {
            return categoryAccess.Get(id);
        }

        public bool Create(Category category)
        {
            return categoryAccess.Create(category);
        }

        public bool Update(int id,Category category)
        {
            return categoryAccess.Update(id, category);
        }

        public bool Delete(int id)
        {
            return categoryAccess.Delete(id);
        }

        public List<Book> GetBooksByCategory(int id)
        {
            //usp_Get_Books_By_Category
            return categoryAccess.GetBooksByCategory(id);
        }

    }
}
