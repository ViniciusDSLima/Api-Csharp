using Api.Utilities;
using Api.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace Api.Controllers;
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDTO>(createUserViewModel);
            
            var userCreated = await _userService.Create(userDto);

            return Ok(new ResultViewModel()
            {
                Message = "Usuario criado com sucesso",
                Success = true,
                Data = userCreated
            });
        }
        catch (DomainExceptions ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
}