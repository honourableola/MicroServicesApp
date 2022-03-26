using CourseManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> RegisterUser(User user);
        public Task<User> UpdateCourse(User user);
        public void DeleteUser(User user);
        public Task<User> GetUser(int id);
        public Task<User> GetUser(string email);
        public Task<List<User>> GetUsers();
    }
}
