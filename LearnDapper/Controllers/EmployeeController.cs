using LearnDapper.Model;
using LearnDapper.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo) 
        {
        this.repo = repo;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll() 
        { 
            var _list = await repo.GetAll();
            if (_list != null)
            {
                return Ok(_list);
            }
            else {
                return NotFound();
            }
        }  
        
        [HttpGet("GetOneById/{emp_id}")]
        public async Task<ActionResult> GetOneById(int emp_id) 
        { 
            var _list = await repo.GetOneById(emp_id);
            if (_list != null)
            {
                return Ok(_list);
            }
            else {
                return NotFound();
            }
        }         
        [HttpGet("GetAllByDepartment/{dept_name}")]
        public async Task<ActionResult> GetAllByDepartment(string dept_name) 
        { 
            var _list = await repo.GetAllByDepartment(dept_name);
            if (_list != null)
            {
                return Ok(_list);
            }
            else {
                return NotFound();
            }
        }        
        
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] Employee employee) 
        { 
            var _result = await repo.Create(employee);
            return Ok(_result);
        }       
        
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Employee employee, int emp_id) 
        { 
            var _result = await repo.Update(employee, emp_id);
            return Ok(_result);
        }    
        
        [HttpDelete("Remove/{emp_id}")]
        public async Task<ActionResult> Remove(int emp_id) 
        { 
            var _result = await repo.Remove(emp_id);
            return Ok(_result);
        }
    }
}
