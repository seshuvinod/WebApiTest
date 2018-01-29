using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicareEnrollmentAccessLayer;
using System.Web.Http.Cors;

namespace WEBAPI.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class EnrollmentController : ApiController
    {
        Medicare_EnrollmentContext context = new Medicare_EnrollmentContext();
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var getAllPlanNames = context.HME_HumanaPlans.Select((x, y) => new { PlanYear = x.PlanYear, PlanName = x.PlanName });
            try
            {
                return (getAllPlanNames != null) ? Request.CreateResponse(HttpStatusCode.OK, context.HME_HumanaPlans.Select(x => x).ToList()) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "Records not Found");  
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        }
}
