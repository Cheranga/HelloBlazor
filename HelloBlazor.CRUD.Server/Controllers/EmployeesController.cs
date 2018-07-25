using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloBlazor.CRUD.Server.DAL;
using HelloBlazor.CRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloBlazor.CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _repository.GetEmployeeAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddEmployeeAsync(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.UpdateEmployeeAsync(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}