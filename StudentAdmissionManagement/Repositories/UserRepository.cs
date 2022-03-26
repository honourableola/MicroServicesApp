using CourseManagement.Entities;
using CourseManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseContext _courseContext;

        public UserRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            return _courseContext.Users.Find(id);
        }

        public async Task<User> GetUser(string email)
        {
            return  _courseContext.Users.SingleOrDefault(u => u.Email == email); 
        }

        public async Task<List<User>> GetUsers()
        {
            return _courseContext.Users.ToList();
        }

        public async Task<User> RegisterUser(User user)
        {
             _courseContext.Users.Add(user);
            await _courseContext.SaveChangesAsync();
            return user;

        }

        public Task<User> UpdateCourse(User user)
        {
            throw new NotImplementedException();
        }
    }
}
