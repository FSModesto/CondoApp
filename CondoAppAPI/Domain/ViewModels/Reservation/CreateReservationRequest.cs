namespace Domain.ViewModels.Reservation
{
    public class CreateReservationRequest
    {
        public string Title { get; set; }

        public string LeisureSpace { get; set; }

        public DateTime DateTime { get; set; }
    }
}
