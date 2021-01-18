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
    public class DepartmentController : ControllerBase
    {
        private readonly IFDepartment _iFDepartment;
        private string loggedUser;

        public DepartmentController(IFDepartment iFDepartment,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFDepartment = iFDepartment;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            var departmentCode = _iFDepartment.GetCode(department.DepartmentCode);

            if (departmentCode != null)
            {
                ModelState.AddModelError("DepartmentCode", departmentCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdDepartment = await _iFDepartment.Add(loggedUser,department);
            return CreatedAtAction(nameof(Get), new { id = createdDepartment.IDNo }, createdDepartment);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Department department)
        {
            var editDepartment = await _iFDepartment.Edit(loggedUser,department);
            return Ok(editDepartment);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Department department)
        {
            var deleteDepartment = await _iFDepartment.Delete(loggedUser,department);
            return Ok(deleteDepartment);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _iFDepartment.Get(id);
        }

        [HttpGet]
        public async Task<List<Department>> GetAll()
        {
            return await _iFDepartment.GetAll();
        }
        #endregion
    }
}
