using Microsoft.VisualBasic.CompilerServices;

namespace Service.DTO;

public class UserDTO
{

    public UserDTO()
    {
        
    }

    public UserDTO(long id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }

    public long Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}