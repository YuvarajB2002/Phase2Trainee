using APICodeFirst.Interface;
using APICodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace APICodeFirst.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(c => c.company).ToListAsync();
        }

      

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.empId == id) ?? throw new NullReferenceException();

        }

        public async Task AddEmployee(Employee e)
        {
            await _context.Employees.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int eid)
        {
            var emp = await _context.Employees.FindAsync(eid);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployee(int id, Employee e)
        {
            if (id == e.empId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    } 
}
