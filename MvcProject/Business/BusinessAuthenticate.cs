using MvcProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Business
{
    public class BusinessAuthenticate:IBusinessAuthenticate
    {
        public IRepositoryAuthenticate irepAuth = null;
        
        public BusinessAuthenticate()
        {
            
            irepAuth = new RepositorySql() as IRepositoryAuthenticate;
            
        }
        public BusinessAuthenticate(IRepositoryAuthenticate irepAuthenticate)
        {
            irepAuth = irepAuthenticate;
         
        }
        public bool ValidateUser(string user, string pass)
        {
            return irepAuth.ValidateUser(user, pass);
        }
        public int Register(string userName, string pass, string confirmPass)
        {
            return irepAuth.Register(userName, pass, confirmPass);
        }

        public bool ValidateUsername(string userName)
        {
            return irepAuth.ValidateUsername(userName);
        }
    }
}