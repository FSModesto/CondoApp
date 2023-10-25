using Domain.Enums;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
