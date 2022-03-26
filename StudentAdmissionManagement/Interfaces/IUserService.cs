using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.UserViewModel;

namespace CourseManagement.Interfaces
{
    public interface IUserService
    {
        public Task<BaseResponse> Register(RegisterUserRequestModel model);
        public Task<UserResponseModel> Login(LoginRequestModel model);

        /*public Task<BaseResponse> UpdateCourse(int id, UpdateCourseRequestModel model);       
        public Task<BaseResponse> DeleteCourse(int id);*/
        public Task<UserResponseModel> GetUser(int id);
        public Task<UsersResponseModel> GetUsers();
    }
}
