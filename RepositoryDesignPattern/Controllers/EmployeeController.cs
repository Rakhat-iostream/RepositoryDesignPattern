using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.DTOs;
using RepositoryDesignPattern.Entities.Models;
using RepositoryDesignPattern.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public EmployeeController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.Employee.GetAllEmployees(trackChanges: false);
            return Ok(employees);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _repository.Employee.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateOrUpdateDto dto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = dto.Firstname,
                MiddleName = dto.MiddleName,
                LastName = dto.Lastname
            };

            _repository.Employee.CreateEmployee(employee);
            _repository.Save();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _repository.Employee.UpdateEmployee(employee);

            _repository.Save();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
             _repository.Employee.DeleteEmployee(id);

            _repository.Save();
            return Ok();
        }
    }
}
