using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {

        IDbService _service;

        public StudentController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {

            return Ok(_service.GetStudent());
        }

        [HttpPost]
        public IActionResult ChangeStudent(Student student)
        {

            var wrt = _service.ChangeStudent(student);
            if (wrt == "error")
                return BadRequest(" ");
            
            return Ok(wrt);

        }

        [HttpPost("{id}")]
        public IActionResult RemoveStudent([FromRoute]String id)
        {    
            var wrt = _service.RemoveStudent(id);
           
            if (wrt == "error")
                return BadRequest(" ");

            return Ok(wrt);

        }

    }
}