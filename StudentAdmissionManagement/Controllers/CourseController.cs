using CourseManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.CourseViewModel;

namespace CourseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] CreateCourseRequestModel model)
        {
            return Ok(await _courseService.AddCourse(model));
        }

        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            return Ok(await _courseService.DeleteCourse(id));
        }

        [HttpPut("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, [FromBody] UpdateCourseRequestModel model)
        {
            return Ok(await _courseService.UpdateCourse(id, model));
        }

        [HttpGet("GetCourse/{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            return Ok(await _courseService.GetCourse(id));
        }

        [HttpGet("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _courseService.GetCourses());
        }
    }
}
