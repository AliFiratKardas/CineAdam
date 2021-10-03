using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservation();

        string AddReservation(Reservation reservation);

        Reservation Find(int reservationId);
        string UpdateReservation(Reservation reservation);


        string DeleteReservation(int reservationId);

        List<Reservation> Where(Expression<Func<Reservation, bool>> exp);

        bool Any(Expression<Func<Reservation, bool>> exp);
    }
}
