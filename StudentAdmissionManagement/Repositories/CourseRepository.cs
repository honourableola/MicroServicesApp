using CourseManagement.Entities;
using CourseManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        public CourseRepository(CourseContext context)
        {
            _context = context;
        }
        public async Task<Course> AddCourse(Course course)
        {
                _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public void DeleteCourse(Course course)
        {
            
            _context.Courses.Remove(course);
            _context.SaveChangesAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            return _context.Courses.Find(id);
        }

        public async Task<Course> GetCourse(string name)
        {
            return _context.Courses.SingleOrDefault(c => c.Name == name);
        }

        public async Task<List<Course>> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
