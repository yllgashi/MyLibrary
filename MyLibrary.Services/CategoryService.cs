using MyLibrary.Access;
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
            return categoryAccess.GetList();
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

    }
}
