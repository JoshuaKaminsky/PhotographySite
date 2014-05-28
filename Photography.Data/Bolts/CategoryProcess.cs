using Photography.Core.Contracts.Process;
using Photography.Core.Models;
using Photography.Data.Contracts;
using Photography.Data.Entities;
using Photography.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Bolts
{
    internal class CategoryProcess : BaseProcess, ICategoryProcess
    {
        public CategoryProcess(IUnitOfWork unitOfWork)
            : base (unitOfWork)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return UnitOfWork.Categories.GetAll().Select(category => category.ToModel());
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = UnitOfWork.Categories.GetById(categoryId);
            return category.ToModel();
        }

        public Category AddCategory(string name)
        {
            var category = UnitOfWork.Categories.Get(c => c.Name.ToLower().Equals(name.ToLower()));
            if (category != null)
            {
                return category.ToModel();
            }

            return UnitOfWork.Categories.Add(new CategoryEntity { Name = name }).ToModel();
        }

        public bool DeleteCategory(int categoryId)
        {
            return UnitOfWork.Categories.Delete(categoryId);
        }
    }
}
