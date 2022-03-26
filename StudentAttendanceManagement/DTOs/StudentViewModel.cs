
using StudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DTOs
{
    public class StudentViewModel
    {
        public class CreateStudentRequestModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequestModel
        {
            public string email { get; set; }
            public string Password { get; set; }
        }

        public class UpdateStudentRequestModel
        {         
            public string PhoneNumber { get; set; }
            public string Password { get; set; }
        }

        public class StudentResponseModel : BaseResponse
        {
            public StudentDTO Data { get; set; }
        }

        public class StudentsResponseModel : BaseResponse
        {
            public List<StudentDTO> Data { get; set; } = new List<StudentDTO>();
        }
    }
}
