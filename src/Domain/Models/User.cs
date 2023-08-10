using Core.Exceptions;
using Domain.Validators;
using System.Collections.Generic;
namespace Domain.Models;

public class User : Base
{
    public override bool Validate()
    {
        var validator = new UserValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estao invalidos, por favor corriga-os", _errors);
            }
            
        }

        return true;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User()
    {
        
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        _errors = new List<string>();
    }

    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }
    public void ChangeEmail(string email)
    {
        Email = email;
        Validate();
    }
    public void ChangePassword(string password)
    {
        Password = Password;
        Validate();
    }
}