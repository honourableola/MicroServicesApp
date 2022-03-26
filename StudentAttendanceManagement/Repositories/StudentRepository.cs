using StudentManagement.Entities;
using StudentManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
             _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public async Task<Student> GetStudent(string email)
        {
            return _context.Students.SingleOrDefault(c => c.Email == email);
        }

        public async Task<List<Student>> GetStudents()
        {
            return _context.Students.ToList();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
