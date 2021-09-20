using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using studentApi.Models;
using System.Threading.Tasks;

namespace studentApi.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentContext _studentContext;

        public StudentController(StudentContext context)
        {
            _studentContext = context;
        }
        //GET api/values
        [HttpGet("get_all_student")]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _studentContext.Students.ToList();
        }
        
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Student> GetById(int? id)
        {
            if(id<=0){
                return NotFound("Student Id must be higher than zero");
            }
            Student student = _studentContext.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Student student)
        {
            if(student == null){
                return NotFound("Student data not supplied");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return Ok(student);
        }
        ~StudentController()
        {
            _studentContext.Dispose();
        }
    }    
}