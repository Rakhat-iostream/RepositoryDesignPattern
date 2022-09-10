using RepositoryDesignPattern.Repositories.Employees;
using System;

namespace RepositoryDesignPattern.Repositories
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
