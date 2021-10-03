using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface ISessionRepository
    {
        List<Session> GetSession();

        string AddSession(Session session);

        Session Find(int sessionId);
        string UpdateSession(Session session);


        string DeleteSession(int sessionId);

        List<Session> Where(Expression<Func<Session, bool>> exp);

        bool Any(Expression<Func<Session, bool>> exp);
    }
}
