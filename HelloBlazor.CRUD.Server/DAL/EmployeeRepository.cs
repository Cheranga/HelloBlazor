using HelloBlazor.CRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloBlazor.CRUD.Server.DAL
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _database;

        public EmployeeRepository(EmployeeDbContext database)
        {
            _database = database;
        }

        public Task<List<Employee>> GetAllAsync()
        {
            return _database.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            _database.Employees.Add(employee);
            await _database.SaveChangesAsync();
            return true;            
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _database.Entry(employee).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _database.Employees.FindAsync(id);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            if(employee != null)
            {
                _database.Employees.Remove(employee);
                await _database.SaveChangesAsync();                
            }

            return true;

        }
    }
}
