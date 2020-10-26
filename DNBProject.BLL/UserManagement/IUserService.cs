using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.BLL.UserManagement
{
    public interface IUserService
    {
        User Get(string UserName, string Password);
    }
}
