using Domain.Enums;

namespace Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            Services = new List<Service>();
            Messages = new List<Message>();
            Reservations = new List<Reservation>();
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public EUserType Type { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
