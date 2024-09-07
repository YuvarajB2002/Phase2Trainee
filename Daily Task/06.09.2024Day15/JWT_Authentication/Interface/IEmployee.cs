using APICodeFirst.Model;

namespace APICodeFirst.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);
        
        Task AddEmployee(Employee e);

        Task UpdateEmployee(int id, Employee e);
        Task DeleteEmployee(int  id);

    }
}
