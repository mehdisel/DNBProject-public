
using DNBProject.DAL.EF.Interfaces;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.BLL.UserManagement
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User Get(string UserName, string Password)
        {
            return _userDal.GetByCondition(x=>x.UserName==UserName&&x.Password==Password);
        }
    }
}
