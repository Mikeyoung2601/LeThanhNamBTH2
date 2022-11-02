using LeThanhNamBTH2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LeThanhNamBTH2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) :  base (Options)
        {

        }
        public DbSet<Student> Students {get; set;}
        public DbSet<LeThanhNamBTH2.Models.Employee> Employee { get; set; }
    }
}