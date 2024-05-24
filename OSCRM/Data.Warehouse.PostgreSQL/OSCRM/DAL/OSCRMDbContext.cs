
using DB.Models.OSCRM;
using Microsoft.EntityFrameworkCore;
using Shared.Lib.Models;

namespace Data.Warehouse.PostgreSQL.OSCRM.DAL
{
    public class OSCRMDbContext : DbContext
    {
        public OSCRMDbContext(DbContextOptions<OSCRMDbContext> options) : base(options) { }

        public DbSet<Category> CategoryTbl { get; set; }
        public DbSet<Customer> customerTbl { get; set; }
    }
}
