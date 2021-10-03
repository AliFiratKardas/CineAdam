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
    public class SaloonRepository : ISaloonRepository
    {

        private readonly MovieContext movieContext;

        public SaloonRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }

        public string AddSaloon(Saloon saloon)
        {

            try
            {

                movieContext.Saloons.Add(saloon);
                movieContext.SaveChanges();
                return "Ekleme başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool Any(Expression<Func<Saloon, bool>> exp)
        {
            return movieContext.Saloons.Any(exp);
        }

        public string DeleteSaloon(int saloonId)
        {
            try
            {
                movieContext.Saloons.Remove(Find(saloonId));
                movieContext.SaveChanges();
                return "Silme işlemi başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Saloon Find(int saloonId)
        {
            return movieContext.Saloons.Find(saloonId);

        }

        public List<Saloon> GetSaloons()
        {
            return movieContext.Saloons.ToList();
        }

        public string UpdateSaloon(Saloon saloon)
        {
            try
            {
                Saloon updated = Find(saloon.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(saloon);
                movieContext.SaveChanges();
                return "tür güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Saloon> Where(Expression<Func<Saloon, bool>> exp)
        {
            return movieContext.Saloons.Where(exp).ToList();
        }

     
    }
}
