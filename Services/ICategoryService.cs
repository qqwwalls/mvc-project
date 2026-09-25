using System.Collections.Generic;
using mvc.Models;

namespace mvc.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetAll();
}
