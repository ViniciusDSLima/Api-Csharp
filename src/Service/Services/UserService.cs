using AutoMapper;
using Core.Exceptions;
using Domain.Models;
using Infra.Repositories;
using Service.DTO;
using Service.Interfaces;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;

    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }


    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExist = await _userRepository.GetByEmail(userDto.Email);

        if (userExist != null)
        {
            throw new DomainExceptions("Ja existe um usuario cadastrado com o email informado");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);

        if (userExists == null)
        {
            throw new DomainExceptions("Näo existe nenhum usuatio com o id informado!");
        }

        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userUpdeted = await _userRepository.Update(user);
        return _mapper.Map<UserDTO>(userUpdeted);
    }

    public async Task Remove(long id)
    {
        var userExists = await _userRepository.Get(id);

        if (userExists == null)
        {
            throw new DomainExceptions("Nao foi encontrado nenhum usuario com o id informado");
        }
        
        await _userRepository.Remove(id);
        
    }

    public async Task<UserDTO> Get(long Id)
    {
        var user = await _userRepository.Get(Id);

        if (user == null)
        {
            throw new DomainExceptions("Nao foi encontrado nenhum usuario com o id informado");
        }

        return _mapper.Map<UserDTO>(user);
        
    }

    public async Task<List<UserDTO>> Get()
    {
        var allUsers = await _userRepository.Get();

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SeachByName(string nome)
    {
        var allUsers = await _userRepository.SearchByName(nome);

        if (allUsers == null)
        {
            throw new DomainExceptions("Nao foi encontrado nenhum usuario com esse nome no banco de dados");
        }

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SeachByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        if (allUsers == null)
        {
            throw new DomainExceptions("Nao foi encontrado nenhum usuario com esse nome no banco de dados");
        }

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDTO>(user);
    }
}