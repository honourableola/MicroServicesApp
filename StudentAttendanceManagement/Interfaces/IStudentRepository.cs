using StudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces
{
    public interface IStudentRepository
    {
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public void DeleteStudent(Student student);
        public Task<Student> GetStudent(int id);
        public Task<Student> GetStudent(string email);
        public Task<List<Student>> GetStudents();
    }
}
