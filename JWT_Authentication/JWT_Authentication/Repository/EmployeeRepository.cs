using JWT_Authentication.Interface;
using JWT_Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EFDBContext _dbContext = new();

        public EmployeeRepository(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmoloyeeList()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee DeleteEmployee(int Id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(Id);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckEmployee(int id)
        {
            return _dbContext.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
