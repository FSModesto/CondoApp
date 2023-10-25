using Domain.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.Services
{
    public interface IReservationService
    {
        Task Create(CreateReservationRequest request, Guid userId);

        Task<IEnumerable<GetReservationResponse>> Get(Guid userId);
    }
}
