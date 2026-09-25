using System.Collections.Generic;
using System.Linq;
using mvc.Models;

namespace mvc.Services;

public class UserService : IUserService
{
    private readonly ShopDbContext _context;

    public UserService(ShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }
}
