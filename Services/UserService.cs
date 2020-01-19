using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserService
    {
        private RepositoryContext _repositoryContext { get; set; }
        public UserService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

       public Login Login(Login login)
       {
            var user = _repositoryContext.Logins
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (user != null)
            {
                return  _repositoryContext.Logins
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            }
            else return null;       
        }

        public UserModel Register(UserModel newUser)
        {
            var user = _repositoryContext.Users
                .FirstOrDefault(x => x.Email == newUser.Email && x.Password == newUser.Password);
            if (user == null)
            {
                var registredUser = new UserModel
                {
                    Id = Guid.NewGuid(),
                    Email = newUser.Email,
                    Name = newUser.Name,
                    Password = newUser.Password,
                    ConfirmPassword = newUser.ConfirmPassword
                };

                var loginData = new Login
                {
                    Id = registredUser.Id,
                    Email = registredUser.Email,
                    Password = registredUser.Password
                };

                _repositoryContext.Users.Add(registredUser);
                _repositoryContext.Logins.Add(loginData);
                _repositoryContext.SaveChanges();

                return registredUser;
            } else return null;
        }

        public UserModel UpdateUserInfo(UserModel newUser)
        {
            var user = _repositoryContext.Users.FirstOrDefault(x => x.Id == newUser.Id);
            user.Email = newUser.Email;
            user.Name = newUser.Name;
            user.Password = newUser.Password;
            user.ConfirmPassword = newUser.ConfirmPassword;

            var loginData = new Login
            {
                Id = newUser.Id,
                Email = newUser.Email,
                Password = newUser.Password
            };

            _repositoryContext.Users.Update(user);
            _repositoryContext.Logins.Update(loginData);
            _repositoryContext.SaveChanges();

            return user;
        }

        public UserModel GetUserById(string userId)
        {
            return _repositoryContext.Users
                .FirstOrDefault(x => x.Id.ToString() == userId);
        }
    }
}
