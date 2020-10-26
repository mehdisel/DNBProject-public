using DNBProject.DAL.DatabaseContext;
using DNBProject.DAL.EF.Interfaces;
using DNBProject.DAL.EF.Repository;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.DAL.EF.DalClasses
{
    public class UserDal : EFEntityRepositoryBase<User, DNBProjectContext>, IUserDal
    {

    }
    
}
