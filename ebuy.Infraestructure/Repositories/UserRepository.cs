using ebuy.Application.Common.Interfaces.Repositories;
using ebuy.Domain.Entities;
using ebuy.Infraestructure.Context;

namespace ebuy.Infraestructure.Repositories
{
    public class UserRepository(EbuyDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
    {
    }
}
