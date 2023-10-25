using Domain.Enums;

namespace Domain.Entities
{
    public class Reservation : Entity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string LeisureSpace { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }
    }
}
