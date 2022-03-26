using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.CourseViewModel;

namespace CourseManagement.Interfaces
{
    public interface ICourseService
    {
        public Task<BaseResponse> AddCourse(CreateCourseRequestModel model);
        public Task<BaseResponse> UpdateCourse(int id, UpdateCourseRequestModel model);
        public Task<CourseResponseModel> GetCourse(int id);
        public Task<BaseResponse> DeleteCourse(int id);
        public Task<CoursesResponseModel> GetCourses();
    }
}
