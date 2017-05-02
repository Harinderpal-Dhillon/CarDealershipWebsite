using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Utility
{
    public interface IEntity
    {
        void SetFields(DataRow dt);
    }
}