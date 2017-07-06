using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ScheduleAppointmentController : Controller
    {
        //
        // GET: /ScheduleAppointment/

        private IBusinessCar iBusiness = null;
        private IBusinessAuthenticate iBusinessAuth = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessCar();
            iBusinessAuth = new BusinessAuthenticate();
            base.Initialize(requestContext);
        }
        public ActionResult Appointment()
        {

            Appointment model = new Appointment();
            return View(model);
        }


        [HttpPost]
        public ActionResult Appointment(Appointment model)
        {
            if(Session["loggedIn"]==null)
            {
                
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                if (model.Username == null && model.Email == null && model.Comment == null)
                {
                    model.Status = "Enter all the fields";
                }
                else
                {
                    int row = iBusiness.ScheduleAppnt(model.Username, model.Email, model.Phone, model.Comment);
                    if (row != 0)
                    {
                        model.Status = "You details has been registered successfully.... You will get an Email confirmation...";
                    }
                }
             
            }
           
            return View(model);
        }

    }
}
