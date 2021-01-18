using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IFEmployee _iFEmployee;
        private string loggedUser;

        public EmployeeController(IFEmployee iFEmployee, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFEmployee = iFEmployee;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            var employeeCode = _iFEmployee.GetCode(employee.EmployeeCode);

            if (employeeCode != null)
            {
                ModelState.AddModelError("EmployeeCode", employeeCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdEmployee = await _iFEmployee.Add(loggedUser,employee);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee.IDNo }, createdEmployee);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var editEmployee = await _iFEmployee.Edit(loggedUser,employee);
            return Ok(editEmployee);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Employee employee)
        {
            var deleteEmployee = await _iFEmployee.Delete(loggedUser,employee);
            return Ok(deleteEmployee);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _iFEmployee.Get(id);
        }

        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            return await _iFEmployee.GetAll();
        }
        #endregion
    }
}
