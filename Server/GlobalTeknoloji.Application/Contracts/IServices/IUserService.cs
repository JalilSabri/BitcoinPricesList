using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTeknoloji.Domain.Models.user;

namespace GlobalTeknoloji.Application.Contracts.IServices;

public interface IUserService
{
    public UserInfo ValidateUserCredentials(string? userName, string? password);
}
