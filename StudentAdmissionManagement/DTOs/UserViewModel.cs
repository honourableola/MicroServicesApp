using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.DTOs
{
    public class UserViewModel
    {
        public class RegisterUserRequestModel
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequestModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponseModel : UserDTO
        {
            public string Token { get; set; }
        }
        public class UserResponseModel : BaseResponse
        {
            public UserDTO Data { get; set; }
        }

        public class UsersResponseModel : BaseResponse
        {
            public List<UserDTO> Data { get; set; }
        }
    }
}
