using Photography.Core.Contracts.Process;
using Photography.Core.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Service.Bolts
{
    internal class CategoryService : BaseService<ICategoryProcess>, ICategoryService
    {
        public CategoryService(ICategoryProcess process)
            : base(process)
        {
        }

        public IEnumerable<Core.Models.Category> GetCategories()
        {
            return Process.GetCategories();
        }

        public Core.Models.Category GetCategoryById(int categoryId)
        {
            return Process.GetCategoryById(categoryId);
        }


        public Core.Models.Category CreateCategory(string name)
        {
            return Process.AddCategory(name);
        }

        public bool DeleteCategory(int categoryId)
        {
            return Process.DeleteCategory(categoryId);
        }
    }
}
