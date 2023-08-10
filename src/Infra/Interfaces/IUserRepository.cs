using Domain.Models;

namespace Infra.Repositories;



public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByEmail(string email);
    Task<List<User>> SearchByName(string name);
    
}