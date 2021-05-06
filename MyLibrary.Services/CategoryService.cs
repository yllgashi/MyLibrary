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

        public List<Category> GetAll()
        {
            return categoryAccess.GetAll();
        }

        public Category Get (string id)
        {
            return categoryAccess.Get(id);
        }

        public bool Create(Category category)
        {
            return categoryAccess.Create(category);
        }

        public bool Update(string id,Category category)
        {
            return categoryAccess.Update(id, category);
        }

        public bool Delete(string id)
        {
            return categoryAccess.Delete(id);
        }



    }
}
