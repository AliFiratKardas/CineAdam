using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly MovieContext movieContext;



        public UserRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }




        public string AddUser(User user)
        {
            try
            {
                movieContext.Users.Add(user);
                movieContext.SaveChanges();
                return "kayıt başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            };
        }

        public bool Any(Expression<Func<User, bool>> exp)
        {
            return movieContext.Users.Any(exp);

        }

        public string DeleteUser(int userId)
        {
            try
            {
                movieContext.Users.Remove(Find(userId));
                movieContext.SaveChanges();
                return "silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public User Find(int userId)
        {
            return movieContext.Users.Find(userId);
        }

        public List<User> GetUsers()
        {
            return movieContext.Users.ToList();
        }

        public string UpdateUser(User user)
        {

            try
            {
                //ID int tipine çevrildi.Sorun çıkabilir sor!
                User updated = Find(Convert.ToInt32(user.Id));
                movieContext.Entry(updated).CurrentValues.SetValues(user);
                return " güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<User> Where(Expression<Func<User, bool>> exp)
        {
            return movieContext.Users.Where(exp).ToList();
        }
    }
}
