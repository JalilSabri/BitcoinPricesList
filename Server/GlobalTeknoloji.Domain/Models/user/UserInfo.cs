using GlobalTeknoloji.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTeknoloji.Domain.Models.user;

[Table("tblUserInfo")]
public class UserInfo : BaseEntity
{
    public string UserName { get; set; } = "Jalil";
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; } = null;
    public string Password { get; set; } = "123";
}
