using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Entities
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
