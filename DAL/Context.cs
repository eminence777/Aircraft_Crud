using Microsoft.EntityFrameworkCore;
using Aircraft_Crud.Models;

namespace Aircraft_Crud.DAL
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Aeronaves> Aeronaves { get; set; }

    }

}
