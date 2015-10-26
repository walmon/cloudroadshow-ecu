using CloudRoadshow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CloudRoadshow.Web.Controllers
{
    public class InvoicesController : ApiController
    {
        IInvoiceDS ds = new InvoiceDS();
        public Invoice Get(Guid id)
        {
            return ds.GetById(id);
        }
        public Invoice[] Get()
        {
            return ds.GetAll().ToArray();
        }
        public IHttpActionResult Insert(Invoice invoice)
        {
            try
            {
                ds.AddNew(invoice);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
