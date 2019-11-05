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
    public class CourseController : ControllerBase
    {
        ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        [HttpGet("Select/{CourseId}")]
        public async Task<ActionResult> Select(string CourseId)
        {
            var results = await _courseRepository.Select(CourseId);
            return Ok(results);

        }

        [HttpPost("Insert")]
        public async Task<ActionResult> insert(Course course)
        {
            await _courseRepository.Insert(course);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(Course course)
        {
            await _courseRepository.Update(course);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(string CourseId)
        {
            await _courseRepository.Delete(CourseId);
            return Ok();
        }
    }
}