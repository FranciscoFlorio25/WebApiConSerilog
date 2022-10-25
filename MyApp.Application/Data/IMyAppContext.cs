using Microsoft.EntityFrameworkCore;
using MyApp.Domian.Entities;

namespace MyApp.Application.Data
{
    public interface IMyAppContext
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
