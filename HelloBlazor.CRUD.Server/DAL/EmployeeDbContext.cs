using HelloBlazor.CRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloBlazor.CRUD.Server.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=HelloBlazorDb;Integrated Security=True;Connect Timeout=30;");
        }
    }
}
