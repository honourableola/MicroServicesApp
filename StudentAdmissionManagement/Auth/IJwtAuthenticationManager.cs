using CourseManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Auth
{
    public interface IJwtAuthenticationManager
    {
        public string GenerateToken(UserDTO user);
    }
}
