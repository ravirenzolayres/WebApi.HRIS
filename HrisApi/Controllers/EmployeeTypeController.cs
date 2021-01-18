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
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IFEmployeeType _iFEmployeeType;
        private string loggedUser;

        public EmployeeTypeController(IFEmployeeType iFEmployeeType,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFEmployeeType = iFEmployeeType;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeType employeeType)
        {
            var employeeTypeCode = _iFEmployeeType.GetCode(employeeType.EmployeeTypeCode);

            if (employeeTypeCode != null)
            {
                ModelState.AddModelError("EmployeeTypeCode", employeeTypeCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdEmployeeType = await _iFEmployeeType.Add(loggedUser,employeeType);
            return CreatedAtAction(nameof(Get), new { id = createdEmployeeType.IDNo }, createdEmployeeType);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(EmployeeType employeeType)
        {
            var editEmployeeType = await _iFEmployeeType.Edit(loggedUser,employeeType);
            return Ok(editEmployeeType);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(EmployeeType employeeType)
        {
            var deleteEmployeeType = await _iFEmployeeType.Delete(loggedUser,employeeType);
            return Ok(deleteEmployeeType);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<EmployeeType> Get(int id)
        {
            return await _iFEmployeeType.Get(id);
        }

        [HttpGet]
        public async Task<List<EmployeeType>> GetAll()
        {
            return await _iFEmployeeType.GetAll();
        }
        #endregion
    }
}
