using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class FinanceController : Controller
    {
        //
        // GET: /Finance/

        private IBusinessAuthenticate iBusiness = null;
        private IBusinessCar iBusinessCar = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessAuthenticate();
            iBusinessCar = new BusinessCar();
            base.Initialize(requestContext);
        }

        public ActionResult Finance()

        {
            FinanceDetails model = new FinanceDetails();
            return View(model);
        }

        [HttpPost]
        public ActionResult Finance(FinanceDetails model)
        {
            int rows = iBusinessCar.Finance(model);
            if(rows!=0)
            {
                model.Status = "Successfully Added";
            }
            else
            {
                model.Status = "Error";
            }
            return View(model);
        }

    }
}
