using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Entities;
using RepositoryDesignPattern.Repositories.Employees;
using System;

namespace RepositoryDesignPattern.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryDbContext _repositoryDbContext;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryDbContext);
                return _employeeRepository;
            }
        }

        public void Save() => _repositoryDbContext.SaveChanges();
    }
}
