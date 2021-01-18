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
    public class CompanyController : ControllerBase
    {
        private readonly IFCompany _iFCompany;
        private string loggedUser;

        public CompanyController(IFCompany iFCompany, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFCompany = iFCompany;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Company company)
        {
            var companyCode = _iFCompany.GetCode(company.CompanyCode);

            if (companyCode != null)
            {
                ModelState.AddModelError("CompanyCode", companyCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdCompany = await _iFCompany.Add(loggedUser,company);
            return CreatedAtAction(nameof(Get), new { id = createdCompany.IDNo }, createdCompany);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Company company)
        {
            var editCompany = await _iFCompany.Edit(loggedUser,company);
            return Ok(editCompany);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Company company)
        {
            var deleteCompany = await _iFCompany.Delete(loggedUser,company);
            return Ok(deleteCompany);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {
            return await _iFCompany.Get(id);
        }

        [HttpGet]
        public async Task<List<Company>> GetAll()
        {
            return await _iFCompany.GetAll();
        }
        #endregion
    }
}
