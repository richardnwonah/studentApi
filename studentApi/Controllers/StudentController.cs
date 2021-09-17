using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using studentApi.Models;


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
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _studentContext.Students.ToList();
        }
        
        ~StudentController()
        {
            _studentContext.Dispose();
        }
    }    
}