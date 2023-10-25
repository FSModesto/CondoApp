using Domain.Enums;

namespace Domain.Entities
{
    public class Service : Entity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public User User { get; set; }
    }
}
