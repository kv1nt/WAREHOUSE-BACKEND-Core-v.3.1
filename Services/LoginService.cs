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
            var user = _repositoryContext.Logins
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if(user != null) return user;
              else return null;       
        }

        public bool Register(Login newUser)
        {
            var user = _repositoryContext.Logins.Where(x => x.Id == newUser.Id);
            if (user == null)
            {
                _repositoryContext.Logins.Add(new Login
                {
                    Id = Guid.NewGuid(),
                    Email = newUser.Email,
                    Password = newUser.Password
                }); return true;
            } else return false;
        }
    }
}
