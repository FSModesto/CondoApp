using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(CondoAppContext context) : base(context)
        {
        }
    }
}