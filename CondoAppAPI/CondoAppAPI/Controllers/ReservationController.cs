using Domain.Enums;
using Domain.Interfaces.Services;
using Domain.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CondoAppAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> Create(CreateReservationRequest request, Guid userId)
        {
            await _service.Create(request, userId);
            return Ok(HttpStatusCode.Created);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<GetReservationResponse>>> Get(Guid userId)
        {
            IEnumerable<GetReservationResponse> results =  await _service.Get(userId);
            return Ok(results);
        }
    }
}