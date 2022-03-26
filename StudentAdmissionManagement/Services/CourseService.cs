using CourseManagement.DTOs;
using CourseManagement.Entities;
using CourseManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.CourseViewModel;

namespace CourseManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async  Task<BaseResponse> AddCourse(CreateCourseRequestModel model)
        {
            var courseExist = await _courseRepository.GetCourse(model.Name);
            if (courseExist != null)
            {
                throw new Exception($"Course already exist");
            }

            var course = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            await _courseRepository.AddCourse(course);

            return new BaseResponse
            {
                Message = $"Course Created Successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> DeleteCourse(int id)
        {
            var course = await _courseRepository.GetCourse(id);
            if (course == null)
            {
                throw new Exception($"Course does not exist");
            }

             _courseRepository.DeleteCourse(course);

            return new BaseResponse
            {
                Message = $"{course.Name} deleted successfully",
                Status = true
            };
        }

        public async Task<CourseResponseModel> GetCourse(int id)
        {
            var course = await _courseRepository.GetCourse(id);
            if (course == null)
            {
                throw new Exception($"Course does not exist");
            }

            var courseReturned = new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            };

            return new CourseResponseModel
            {
                Data = courseReturned,
                Message = $"{course.Name} retrieved successfully",
                Status = true
            };
        }

        public async Task<CoursesResponseModel> GetCourses()
        {
            var courses = await _courseRepository.GetCourses();
            if (courses.Count == 0)
            {
                throw new Exception($"No courses found");
            }

            var coursesReturned = courses.Select(course => new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            }).ToList();
            

            return new CoursesResponseModel
            {
                Data = coursesReturned,
                Message = $"Courses retrieved successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> UpdateCourse(int id, UpdateCourseRequestModel model)
        {
            var course = await _courseRepository.GetCourse(id);
            if (course == null)
            {
                throw new Exception($"Course does not exist");
            }

            course.Description = model.Description;
            await _courseRepository.UpdateCourse(course);
            return new BaseResponse
            {
                Message = $"{course.Name} updated successfully",
                Status = true
            };

        }
    }
}
