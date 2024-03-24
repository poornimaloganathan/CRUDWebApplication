using Microsoft.EntityFrameworkCore;
using CRUDWebApplication.Models;

namespace CRUDWebApplication.Data
{
    public class DetailsDbContext : DbContext
    {
        public DetailsDbContext(DbContextOptions<DetailsDbContext> options) : base(options)
        {
        }

        public DbSet<Details> Details { get; set; }
    }

}

