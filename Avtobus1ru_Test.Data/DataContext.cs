using Avtobus1ru_Test.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1ru_Test.Data
{
    public class DataContext : DbContext
    {
        public DbSet<LinkEntity> Links { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
