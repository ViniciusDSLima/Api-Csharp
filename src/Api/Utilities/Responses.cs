using Api.ViewModels;

namespace Api.Utilities;

public static class Responses
{
    public static ResultViewModel ApplicationErrorMessage()
    {
        return new ResultViewModel()
        {
            Message = "Ocoreu algum erro interno na aplicaco, por gentileza tente novamente",
            Success = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
        return new ResultViewModel()
        {
            Message = message,
            Success = false,
            Data = null
        };
    }
    
    public static ResultViewModel DomainErrorMessage(string message, List<string> erros)
    {
        return new ResultViewModel()
        {
            Message = message,
            Success = false,
            Data = null
        };
    }
    
    public static ResultViewModel UnauthorizedErrorMessage()
    {
        return new ResultViewModel()
        {
            Message = "A combinacao de login e senha está incorreta",
            Success = false,
            Data = null
        };
    }
}