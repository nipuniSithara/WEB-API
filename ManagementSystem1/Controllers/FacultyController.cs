using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;

namespace ManagementSystem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            this._facultyRepository = facultyRepository;
        }

        [HttpGet("Select/{FacultyId}")]
        public async Task<ActionResult> Select(string FacultyId)
        {
            var results = await _facultyRepository.Select(FacultyId);
            return Ok(results);

        }

        [HttpPost("Insert")]
        public async Task<ActionResult> insert(Faculty faculty)
        {
            await _facultyRepository.Insert(faculty);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(Faculty faculty)
        {
            await _facultyRepository.Update(faculty);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string FacultyId)
        {
            await _facultyRepository.Delete(FacultyId);
            return Ok();
        }
    }
}