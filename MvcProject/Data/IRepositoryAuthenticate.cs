using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Data
{
    public interface IRepositoryAuthenticate
    {
        //string GetRolesForUser(string uname);
        //bool SignIn(string userName, string password, bool createPersistentCookie);
        //bool ChangePassword(string userName, string password, string newPassword);
        //void SignOut();
        bool ValidateUser(string userName, string password);
        int Register(string userName, string pass, string confirmPass);
        //RegistrationModel GetCustomerInfo(string userName);
        //bool UpdateCustomer(RegistrationModel Info);
    }
}