using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.Reservation;

namespace Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateReservationRequest request, Guid userId)
        {
            var reservation = new Reservation()
            {
                Title = request.Title,
                LeisureSpace = request.LeisureSpace,
                DateTime = request.DateTime,
                CreateAt = DateTime.Now,
                UserId = userId
            };
             
            await _repository.Create(reservation);
        }

        public async Task<IEnumerable<GetReservationResponse>> Get(Guid userId)
        {
            IEnumerable<Reservation> reservations =
                await _repository.Query(wh => wh.UserId == userId);

            List<GetReservationResponse> result = new List<GetReservationResponse>();

            foreach (Reservation reservation in reservations)
            {
                GetReservationResponse response = new GetReservationResponse
                {
                    Id = reservation.Id,
                    Title = reservation.Title,
                    LeisureSpace = reservation.LeisureSpace,
                    DateTime = reservation.DateTime
                };

                result.Add(response);
            }

            return result;
        }
    }
}
