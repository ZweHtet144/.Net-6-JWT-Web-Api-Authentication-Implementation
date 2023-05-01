using JWT_Authentication.Models;

namespace JWT_Authentication.Interface
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee DeleteEmployee(int Id);
        List<Employee> GetEmoloyeeList();
        Employee GetEmployee(int id);
        void UpdateEmployee(Employee employee);
        public bool CheckEmployee(int id);
    }
}