using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CondoAppContext context) : base(context)
        {
        }
    }
}