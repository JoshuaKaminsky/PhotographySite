using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Core.Contracts.Service
{
    public interface ICategoryService : IService
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        Category CreateCategory(string name);

        bool DeleteCategory(int categoryId);
    }
}
