using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiCustomerInfo.Models;

namespace WebApiCustomerInfo.Controllers
{
    public class CustomerInformationsController : ApiController
    {
        private InfoDBEntities db = new InfoDBEntities();

        // GET: api/CustomerInformations
        public IQueryable<CustomerInformation> GetCustomerInformations()
        {
            return db.CustomerInformations;
        }

        // GET: api/CustomerInformations/5
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult GetCustomerInformation(int id)
        {
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            return Ok(customerInformation);
        }

        // PUT: api/CustomerInformations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerInformation(int id, CustomerInformation customerInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerInformation.CustID)
            {
                return BadRequest();
            }

            db.Entry(customerInformation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerInformations
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult PostCustomerInformation(CustomerInformation customerInformation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.CustomerInformations.Add(customerInformation);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }


            return CreatedAtRoute("DefaultApi", new { id = customerInformation.CustID }, customerInformation);
        }

        // DELETE: api/CustomerInformations/5
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult DeleteCustomerInformation(int id, [FromUri] bool status)
        {
            CustomerInformation customerInformation = db.CustomerInformations.Find(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            //db.CustomerInformations.Remove(customerInformation);             
            //db.SaveChanges();             
            if (customerInformation != null)
            {
                customerInformation.Status = status;
                db.SaveChanges();
            }

            return Ok(customerInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerInformationExists(int id)
        {
            return db.CustomerInformations.Count(e => e.CustID == id) > 0;
        }
    }
}