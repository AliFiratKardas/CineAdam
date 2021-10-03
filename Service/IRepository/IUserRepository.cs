using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();


        string AddUser(User user);

        User Find(int userId);

        string UpdateUser(User user);

        string DeleteUser(int userId);

        List<User> Where(Expression<Func<User, bool>> exp);

        bool Any(Expression<Func<User, bool>> exp);
    }
}
