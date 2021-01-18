using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCustomScheduleController : ControllerBase
    {
        private readonly IFEmployeeCustomSchedule _iFEmployeeCustomSchedule;
        private string loggedUser;

        public EmployeeCustomScheduleController(IFEmployeeCustomSchedule iFEmployeeCustomSchedule,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFEmployeeCustomSchedule = iFEmployeeCustomSchedule;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeCustomSchedule employeeCustomSchedule)
        {
            var createdEmployeeCustomSchedule = await _iFEmployeeCustomSchedule.Add(loggedUser, employeeCustomSchedule);
            return CreatedAtAction(nameof(Get), new { id = createdEmployeeCustomSchedule.IDNo }, createdEmployeeCustomSchedule);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(EmployeeCustomSchedule employeeCustomSchedule)
        {
            var editEmployeeCustomSchedule = await _iFEmployeeCustomSchedule.Edit(loggedUser, employeeCustomSchedule);
            return Ok(editEmployeeCustomSchedule);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(EmployeeCustomSchedule employeeCustomSchedule)
        {
            var deleteEmployeeCustomSchedule = await _iFEmployeeCustomSchedule.Delete(loggedUser, employeeCustomSchedule);
            return Ok(deleteEmployeeCustomSchedule);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<EmployeeCustomSchedule> Get(int id)
        {
            return await _iFEmployeeCustomSchedule.Get(id);
        }

        [HttpGet]
        public async Task<List<EmployeeCustomSchedule>> GetAll()
        {
            return await _iFEmployeeCustomSchedule.GetAll();
        }
        #endregion
    }
}
