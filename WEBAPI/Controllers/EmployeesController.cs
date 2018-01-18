using System.Web.Http;
using GetAll;
using System.Collections.Generic;
using System.Linq;
using DbContext;
using System.Net.Http;
using System.Net;
using System;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Threading;
using System.Security.Authentication;
namespace WEBAPI.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
   
    public class EmployeesController : ApiController
    {
        
        vinudbContext context = new vinudbContext();
        [System.Web.Http.HttpGet]

        public HttpResponseMessage Get(string gender="All")
        {

         //string userName=Thread.CurrentPrincipal.Identity.Name;

            try
            {
             
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, context.Employees.Select(x => x).ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, context.Employees.Where(x => x.Gender == "Male"));
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, context.Employees.Where(x => x.Gender == "Female"));
                    case "unknown":
                        return Request.CreateResponse(HttpStatusCode.OK, context.Employees.Where(x => x.Gender == "Unknown"));
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "could not find gender with name " + gender);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        public List<Employee> obselete()

        {
            return context.Employees.Select(x => x).ToList();

            // return Employeess.employees;
        }
       
        public Employee getall(int id)
        {
          return context.Employees.FirstOrDefault(x => x.Id == id);
        }
        public void Post([FromBody]Employee value)
        {
            context.Employees.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody]int id, [FromUri]Employee value)
        {
            var result = context.Employees.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot find record with id"+" "+id.ToString());
            }
            else
            {
                result.Name = value.Name;
                result.Age = value.Age;
                result.Salary = value.Salary;
                //context.Employees.ToList()[id] = value;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "ID is" + id.ToString() + " is Present");
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var res = context.Employees.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User Id " + res.Id + "not found");
            }
            else
            {
                context.Employees.ToList().RemoveAt(id);
                context.SaveChangesAsync();
                return Request.CreateResponse(HttpStatusCode.OK, "User Id " + res.Id + "was found");
            }
        }
    }

}
