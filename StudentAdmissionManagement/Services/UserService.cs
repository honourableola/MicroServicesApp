using CourseManagement.DTOs;
using CourseManagement.Entities;
using CourseManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourseManagement.DTOs.UserViewModel;

namespace CourseManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponseModel> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if(user == null)
            {
                throw new Exception($"User does not exist");
            }

            return new UserResponseModel
            {
                Data = new UserDTO 
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email                    
                },
                Message = $"User retrieved successfully",
                Status = true
            };
        }

        public async Task<UsersResponseModel> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            if (users.Count == 0)
            {
                return new UsersResponseModel
                {
                    Data = null,
                    Message = $"No user found",
                    Status = false
                };
            }

            return new UsersResponseModel
            {
                Data = users.Select(user => new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }).ToList(),
                Message = $"{users.Count} users retrieved successfully",
                Status = true
            };
        }

        public async Task<UserResponseModel> Login(LoginRequestModel model)
        {
            var user = await _userRepository.GetUser(model.Email);
            if (user == null || user.Password != model.Password)
            {
                throw new Exception($"Invalid username of password");
            }
            return new UserResponseModel
            {
                Data = new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                },
                Message = $"Login successful",
                Status = true
            };
        }

        public async Task<BaseResponse> Register(RegisterUserRequestModel model)
        {
            var isUserExist = await _userRepository.GetUser(model.Email);
            if (isUserExist != null)
            {
                throw new Exception($"User already exist");
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };

            await _userRepository.RegisterUser(user);

            return new BaseResponse
            {            
                Message = $"User created successfully",
                Status = true
            };
        }
    }
}
