using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IInteresDbContext
{
    DbSet<Interes> Interests { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}