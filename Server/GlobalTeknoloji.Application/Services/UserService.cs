using GlobalTeknoloji.Application.Contracts.IServices;
using GlobalTeknoloji.Data.Repositories;
using GlobalTeknoloji.Domain.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Application.Services
{
    public class UserService : IUserService
    {
        IBaseRepository<UserInfo> _baseRepository;

        public UserService(IBaseRepository<UserInfo> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public UserInfo ValidateUserCredentials(string? userName, string? password)
        {
            var userInfo = _baseRepository.GetFirst(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            return userInfo;
        }


    }
}
