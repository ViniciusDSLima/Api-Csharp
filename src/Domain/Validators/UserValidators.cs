using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade nao pode ser vazia")
        
            .NotNull()
            .WithMessage("A entidade nao pode ser vazia");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome nao pode ser vazio")

            .NotNull()
            .WithMessage("O nome nao pode ser nulo")

            .MinimumLength(3)
            .WithMessage("O tamanho minimo para o nome säo 3 caracteres")

            .MaximumLength(100)
            .WithMessage("O tamanho maximo para o nome säo 100 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O email nao pode ser vazio")

            .NotNull()
            .WithMessage("O email nao pode ser nulo")

            .MinimumLength(10)
            .WithMessage("O tamanho minimo para o email säo 10 caracteres")

            .MaximumLength(50)
            .WithMessage("O tamanho maximo para o email säo 50 caracteres");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("A senha nao pode ser vazia")

            .NotNull()
            .WithMessage("A senha nao pode ser nula")

            .MinimumLength(8)
            .WithMessage("O tamanho minimo para a senha säo 8 caracteres")

            .MaximumLength(14)
            .WithMessage("O tamanho maximo para a senha säo 14 caracteres");
    }
}