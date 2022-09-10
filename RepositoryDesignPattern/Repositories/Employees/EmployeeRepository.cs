using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities;
using RepositoryDesignPattern.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Repositories.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToList();

        public async Task<Employee> GetEmployee(Guid employeeId)
        {
            return await _repositoryDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public void CreateEmployee(Employee employee) => Create(employee);

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _repositoryDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.MiddleName = employee.MiddleName;
                result.LastName = employee.LastName;

                await _repositoryDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteEmployee(Guid id)
        {
            var result = await _repositoryDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _repositoryDbContext.Employees.Remove(result);
                await _repositoryDbContext.SaveChangesAsync();
            }
        }
    }
}