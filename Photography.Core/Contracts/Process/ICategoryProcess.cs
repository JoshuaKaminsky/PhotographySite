using Photography.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Core.Contracts.Process
{
    public interface ICategoryProcess : IProcess
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int categoryId);
    }
}
