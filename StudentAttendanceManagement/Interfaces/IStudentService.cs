
using StudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentManagement.DTOs.StudentViewModel;

namespace StudentManagement.Interfaces
{
    public interface IStudentService
    {
        public Task<BaseResponse> AddStudent(CreateStudentRequestModel model);
        public Task<BaseResponse> UpdateStudent(int id, UpdateStudentRequestModel model);
        public Task<StudentResponseModel> GetStudent(int id);
        public Task<BaseResponse> DeleteStudent(int id);
        public Task<StudentsResponseModel> GetStudents();
        public Task<Student> Login(string email, string password);
    }
}
