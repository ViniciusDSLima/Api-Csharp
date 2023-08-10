using Service.DTO;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserDTO> Create(UserDTO userDto);
    Task<UserDTO> Update(UserDTO userDto);
    Task Remove(long Id);
    Task<UserDTO> Get(long Id);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SeachByName(string nome);
    Task<List<UserDTO>> SeachByEmail(string email);
    Task<UserDTO> GetByEmail(string email);
}