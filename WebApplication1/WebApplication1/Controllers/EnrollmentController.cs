using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/Enrollment")]
    public class EnrollmentController : ControllerBase
    {

        IDbService _service;

        public EnrollmentController(IDbService service)
        {

            _service = service;

        }
        

        [HttpGet]
        public IActionResult GetEnrollment()
        {
           return  Ok(_service.GetEnrollment());
        }

        [HttpPost]
        public IActionResult PostEnroll(EnrollStudentRequest req)
        {

            var str = _service.EnrollStudent(req);

            if (str.Contains( "error"))
                return BadRequest(str);
            return Ok(str);

        }

        [HttpPost("promote")]
        public IActionResult Promote(PromoteStudentRequest req)
        {

            var str = _service.PromoteStudents(req);
            return Ok(str);

        }

    }
}