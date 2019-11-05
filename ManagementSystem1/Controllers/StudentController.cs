using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Fireball.Utilities.ExceptionManagment;
using Models;

namespace ManagementSystem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;


        }
        
        [HttpGet("Select/{StudentId}")]
        public async Task<ActionResult>Select(string StudentId)
        {
            var results = await _studentRepository.Select(StudentId);
            return Ok(results);

        }

        [HttpPost("Insert")]
        public async Task<ActionResult> insert(Student student)
        {
            await _studentRepository.Insert(student);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(Student student)
        {
            await _studentRepository.Update(student);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string StudentId)
        {
            await _studentRepository.Delete(StudentId);
            return Ok();
        }
    }
}