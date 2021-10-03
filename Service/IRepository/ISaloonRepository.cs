using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface ISaloonRepository
    {
        List<Saloon> GetSaloons();


        string AddSaloon(Saloon saloon);

        Saloon Find(int saloonId);
        string UpdateSaloon(Saloon saloon);


        string DeleteSaloon(int saloonId);

        List<Saloon> Where(Expression<Func<Saloon, bool>> exp);

        bool Any(Expression<Func<Saloon, bool>> exp);
    }
}
