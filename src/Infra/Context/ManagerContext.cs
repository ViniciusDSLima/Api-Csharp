using Api.Infra.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;
public class ManagerContext : DbContext
{
    public ManagerContext()
    {
        
    }

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    {
        
    }
    
    
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}