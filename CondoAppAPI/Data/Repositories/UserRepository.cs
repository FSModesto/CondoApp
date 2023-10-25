using Data.Contexts;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CondoAppContext context) : base(context)
        {
        }
    }
}