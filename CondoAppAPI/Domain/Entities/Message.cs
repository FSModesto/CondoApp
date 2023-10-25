using Domain.Enums;

namespace Domain.Entities
{
    public class Message : Entity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool HasBeenReaded { get; set; } = false;

        public DateTime DateTime { get; set; }

        public EMessageType Type { get; set; }

        public User User { get; set; }
    }
}