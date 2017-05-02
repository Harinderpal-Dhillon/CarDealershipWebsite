using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Business
{
    public interface IBusinessAuthenticate
    {
        bool ValidateUser(string userName, string password);
        int Register(string userName, string pass, string confirmPass);
    }
}