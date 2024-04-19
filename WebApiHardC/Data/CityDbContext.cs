using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiP2.Domain.Model;

namespace WebApiP2.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {   
        }

        public DbSet<City> cities { get; set; }


    }
}
