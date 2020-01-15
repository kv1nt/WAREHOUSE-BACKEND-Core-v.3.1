using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class LoginService
    {
        private RepositoryContext _repositoryContext { get; set; }
        public LoginService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

       public Login Login(Login login)
       {
            var user = _repositoryContext.Users
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

                _repositoryContext.Users.Add(registredUser);
                _repositoryContext.SaveChanges();

                return registredUser;
            } else return null;
        }
    }
}
