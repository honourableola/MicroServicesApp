using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static StudentManagement.DTOs.StudentViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize]
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentRequestModel model)
        {
            return Ok(await _studentService.AddStudent(model));
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            return Ok(await _studentService.DeleteStudent(id));
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentRequestModel model)
        {
            return Ok(await _studentService.UpdateStudent(id, model));
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            return Ok(await _studentService.GetStudent(id));
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _studentService.GetStudents());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var student = await _studentService.Login(model.email, model.Password);
            if(student == null)
            {
                //throw new Exception($"Invalid UserName or Password");
                return NoContent();
               
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, student.FirstName),
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                new Claim(ClaimTypes.Surname, student.LastName),
                new Claim(ClaimTypes.Email, student.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);
           // var authenticationProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(principal);

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
