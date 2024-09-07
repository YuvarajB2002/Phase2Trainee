using APICodeFirst.Interface;
using APICodeFirst.Model;

namespace APICodeFirst.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _emprepo;
        public EmployeeService(IEmployee emprepo)
        {
            _emprepo = emprepo;
        }   

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _emprepo.GetAllEmployees();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _emprepo.GetEmployeeById(id);
        }

        public async Task AddEmp(Employee e)
        {
            await _emprepo.AddEmployee(e);
        }

        public async Task DeleteEmp(int id)
        {
            await _emprepo.DeleteEmployee(id);
        }

        public async Task UpdateEmp(int id,Employee e)
        {
            await _emprepo.UpdateEmployee(id,e);
        }
    }
}
