
using Microsoft.EntityFrameworkCore;
using Shared.Lib.Models;

namespace Data.Warehouse.PostgreSQL.Rehearsal.DAL
{
    public class RehearsalDbContext : DbContext
    {
        public RehearsalDbContext(DbContextOptions<RehearsalDbContext> options) : base(options) { }

        public DbSet<Category> CategoryTbl { get; set; }
    }
}
