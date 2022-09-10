using RepositoryDesignPattern.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Task<Employee> GetEmployee(Guid employeeId);
        void CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(Guid employeeId);
    }
}
