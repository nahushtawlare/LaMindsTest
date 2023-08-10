using LaMindsTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace LaMindsTest.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Employeeinfo> employeeinfos { get; set; }
        public DbSet<cityinfo> cityinfos { get; set; }
        public DbSet<Statesinfo> Statesinfos { get;set; }


    }
}
