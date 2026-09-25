using System.Collections.Generic;
using mvc.Models;

namespace mvc.Services;

public interface IUserService
{
    IEnumerable<User> GetAll();
}
