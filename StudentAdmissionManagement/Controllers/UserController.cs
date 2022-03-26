using CourseManagement.Auth;
using CourseManagement.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.UserViewModel;

namespace CourseManagement.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public UserController(IUserService userService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userService = userService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestModel model)
        {
            var response = await _userService.Register(model);
            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var response = await _userService.Login(model);

            if (!response.Status)
            {
                return BadRequest();
            }

            var user = response.Data;

            var token = _jwtAuthenticationManager.GenerateToken(user);

            var resp = new LoginResponseModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
            return Ok(resp);
        }

        [Authorize]
        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var response = await _userService.GetUser(id);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }
    }
}
