namespace Domain.Models;
using System.Collections.Generic;


public abstract class Base
{
    public long Id { get; set; }
    
    public List<string> _errors;
    
    public IReadOnlyCollection<string> Errors => _errors;

    public abstract bool Validate();
}