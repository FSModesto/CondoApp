namespace Domain.ViewModels.Reservation
{
    public class GetReservationResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string LeisureSpace { get; set; }

        public DateTime DateTime { get; set; }
    }
}
