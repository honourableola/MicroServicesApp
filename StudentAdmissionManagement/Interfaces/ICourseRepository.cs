using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Interfaces
{
    public interface ICourseRepository
    {
        public Task<Course> AddCourse(Course course);
        public Task<Course> UpdateCourse(Course course);
        public void DeleteCourse(Course course);
        public Task<Course> GetCourse(int id);
        public Task<Course> GetCourse(string name);
        public Task<List<Course>> GetCourses();
    }
}
