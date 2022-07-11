using Microsoft.EntityFrameworkCore;
using WebApiMinimal.Models;

namespace WebApiMinimal.Context
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options) => Database.EnsureCreated();
                       
        public DbSet<Produto> Produto { get; set; }

    }
}
