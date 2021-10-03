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
    public class WeekRepository : IWeekRepository
    {


        private readonly MovieContext movieContext;

        public WeekRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }




        public string AddWeek(Week week)
        {

            try
            {

                movieContext.Weeks.Add(week);
                movieContext.SaveChanges();
                return "Ekleme başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool Any(Expression<Func<Week, bool>> exp)
        {

            return movieContext.Weeks.Any(exp);


        }

        public string DeleteWeek(int weekId)
        {
            try
            {
                movieContext.Weeks.Remove(Find(weekId));
                movieContext.SaveChanges();
                return "Silme işlemi başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Week Find(int weekId)
        {

            return movieContext.Weeks.Find(weekId);
        }

        public List<Week> GetWeeks()
        {

            return movieContext.Weeks.ToList();



        }

        public string UpdateWeeks(Week week)
        {
            try
            {
                Week updated = Find(week.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(week);
                movieContext.SaveChanges();
                return "tür güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public List<Week> Where(Expression<Func<Week, bool>> exp)
        {
            return movieContext.Weeks.Where(exp).ToList();
        }
    }
}
