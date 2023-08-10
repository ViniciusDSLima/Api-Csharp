using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Api.ViewModels;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "O nome nao pode ser vazio")]
    [MinLength(3, ErrorMessage = "O tamanho minimo para o nome säo 3 caracteres")]
    [MaxLength(100, ErrorMessage =  "O tamanho minimo para o nome säo 100 caracteres")]
    public string Name { get;  set; }
    
    [Required(ErrorMessage = "O email nao pode ser vazio")]
    [MinLength(10, ErrorMessage = "O tamanho minimo para o nome säo 10 caracteres")]
    [MaxLength(50, ErrorMessage =  "O tamanho minimo para o nome säo 50 caracteres")]
    public string Email { get;  set; }
    
    [Required(ErrorMessage = "A senha nao pode ser vazia")]
    [MinLength(8, ErrorMessage = "O tamanho minimo para o nome säo 8 caracteres")]
    [MaxLength(14, ErrorMessage =  "O tamanho minimo para o nome säo 14 caracteres")]
    public string Password { get;  set; }
}