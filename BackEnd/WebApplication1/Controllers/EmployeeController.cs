using DAL.Models;
using DAL.Repositories;
using DAL.Helper;
using BLL.Services;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private IEmployeeService _EmpServ;
        public EmployeeController(IEmployeeService service)
        {
            _EmpServ = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmpServ.GetAllEmplyees());
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var emp = _EmpServ.CreateEmployee(employeeVM.ToEntity());
                return Ok(emp);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var isEmpExist = _EmpServ.IsExist(x => x.Id == id);
            if (isEmpExist)
            {
                _EmpServ.DeleteEmployee(id);
                return Ok();
            }
            else
                return BadRequest("no such employee");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeVM employeeVM)
        {
            var isEmpExist = _EmpServ.IsExist(x => x.Id == id);
            if (isEmpExist)
            {
                if (ModelState.IsValid)
                {
                    var emp = _EmpServ.UpdateEmployee(id, employeeVM.ToEntity());
                    return Ok(emp);
                }
                else
                    return BadRequest(ModelState);
            }
            else
                return BadRequest("no such employee");

        }

    }
}