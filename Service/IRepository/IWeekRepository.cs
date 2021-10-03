using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IWeekRepository
    {

        List<Week> GetWeeks();

        string AddWeek(Week week);

        Week Find(int weekId);
        string UpdateWeeks(Week week);


        string DeleteWeek(int weekId);

        List<Week> Where(Expression<Func<Week, bool>> exp);

        bool Any(Expression<Func<Week, bool>> exp);



    }
}
