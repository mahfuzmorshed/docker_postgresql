using Microsoft.EntityFrameworkCore;
using secDockerApp.Models;

namespace secDockerApp.Data
{
    public class SchoolContext : DbContext{
        public SchoolContext(DbContextOptions options):base(options){}
        public DbSet<Student> students{get;set;}
    }
}