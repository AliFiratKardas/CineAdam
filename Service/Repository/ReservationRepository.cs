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
    public class ReservationRepository : IReservationRepository
    {
        private readonly MovieContext movieContext;
        public ReservationRepository(MovieContext _movieContext)
        {
            movieContext = _movieContext;
        }

        public string AddReservation(Reservation reservation)
        {
            try
            {

                movieContext.Reservations.Add(reservation);
                movieContext.SaveChanges();
                return "Ekleme başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public bool Any(Expression<Func<Reservation, bool>> exp)
        {
            return movieContext.Reservations.Any(exp);
        }

        public string DeleteReservation(int reservationId)
        {
            try
            {
                movieContext.Reservations.Remove(Find(reservationId));
                movieContext.SaveChanges();
                return "Silme işlemi başarılı";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Reservation Find(int reservationId)
        {
            return movieContext.Reservations.Find(reservationId);
        }

        public List<Reservation> GetReservation()
        {
            return movieContext.Reservations.ToList();
        }

        public string UpdateReservation(Reservation reservation)
        {
            try
            {
                Reservation updated = Find(reservation.Id);
                movieContext.Entry(updated).CurrentValues.SetValues(reservation);
                movieContext.SaveChanges();
                return "tür güncellendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Reservation> Where(Expression<Func<Reservation, bool>> exp)
        {
            return movieContext.Reservations.Where(exp).ToList();
        }
    }
}
