
using StudentManagement.DTOs;
using StudentManagement.Entities;
using StudentManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentManagement.DTOs.StudentViewModel;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<BaseResponse> AddStudent(CreateStudentRequestModel model)
        {
            var studentExist = await _studentRepository.GetStudent(model.FirstName);
            if (studentExist != null)
            {
                throw new Exception($"Student already exist");
            }

            var student = new Student
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password
            };

            await _studentRepository.AddStudent(student);

            return new BaseResponse
            {
                Message = $"Student Created Successfully",
                Status = true
            };
        }

        public async Task<BaseResponse> DeleteStudent(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new Exception($"Student does not exist");
            }

            _studentRepository.DeleteStudent(student);

            return new BaseResponse
            {
                Message = $"{student.FirstName} {student.LastName} deleted successfully",
                Status = true
            };
        }

        public async Task<StudentResponseModel> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new Exception($"student does not exist");
            }

            var studentReturned = new StudentDTO
            {
                Id = student.Id,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Password = student.Password
            };

            return new StudentResponseModel
            {
                Data = studentReturned,
                Message = $"{student.FirstName} {student.LastName} retrieved successfully",
                Status = true
            };
        }

        public async Task<StudentsResponseModel> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            if (students.Count == 0)
            {
                throw new Exception($"No students found");
            }

            var studentsReturned = students.Select(student => new StudentDTO
            {
                Id = student.Id,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Password = student.Password
            }).ToList();


            return new StudentsResponseModel
            {
                Data = studentsReturned,
                Message = $"Students retrieved successfully",
                Status = true
            };
        }

        public async Task<Student> Login(string email, string password)
        {
            var student = await _studentRepository.GetStudent(email);
            if(student != null && student.Password == password)
            {
                return student;
            }

            return null;
        }

        public async Task<BaseResponse> UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var student = await _studentRepository.GetStudent(id);
            if (student == null)
            {
                throw new Exception($"Student does not exist");
            }

            student.PhoneNumber = model.PhoneNumber;
            student.Password = model.Password;
            await _studentRepository.UpdateStudent(student);
            return new BaseResponse
            {
                Message = $"{student.FirstName} {student.LastName} updated successfully",
                Status = true
            };

        }
    }
}
