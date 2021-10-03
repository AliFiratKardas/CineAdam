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
{//TRANSİENT İŞLEMLERİNİ UNUTMA

    public class SessionRepository : ISessionRepository
    {

        private readonly MovieContext movieContext;

        public SessionRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }
        public string AddSession(Session session)
        {
            try
            {

                movieContext.Sessions.Add(session);
                movieContext.SaveChanges();
                return "Ekleme başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool Any(Expression<Func<Session, bool>> exp)
        {
            return movieContext.Sessions.Any(exp);

        }

        public string DeleteSession(int sessionId)
        {
            try
            {
                movieContext.Sessions.Remove(Find(sessionId));
                movieContext.SaveChanges();
                return "Silme işlemi başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Session Find(int sessionId)
        {
            return movieContext.Sessions.Find(sessionId);

        }

        public List<Session> GetSession()
        {
            return movieContext.Sessions.ToList();
        }

        public string UpdateSession(Session session)
        {
            try
            {
                Session updated = Find(session.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(session);
                movieContext.SaveChanges();
                return "güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Session> Where(Expression<Func<Session, bool>> exp)
        {
            return movieContext.Sessions.Where(exp).ToList();
        }
    }
}
