using MyLibrary.Access;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
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
            // validation
            List<Category> categories = categoryAccess.GetList();
            int exists = categories.FindIndex(x => x.Description == category.Description);
            if (exists != -1) throw new ObjectCreationException();
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
