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
            return UnitOfWork.Categories.GetAll().ToList().Select(category => category.ToModel());
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = UnitOfWork.Categories.GetById(categoryId);
            return category.ToModel();
        }
    }
}
