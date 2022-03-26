using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.DTOs
{
    public class CourseViewModel
    {
        public class CreateCourseRequestModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class UpdateCourseRequestModel
        {
            public string Description { get; set; }
        }

        public class CourseResponseModel : BaseResponse
        {
            public CourseDTO Data { get; set; }
        }

        public class CoursesResponseModel : BaseResponse
        {
            public List<CourseDTO> Data { get; set; } = new List<CourseDTO>();
        }

    }
}
