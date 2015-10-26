using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudRoadshow.Web.Models
{
    public class InvoiceSeedDS : IInvoiceDS
    {
        public List<Invoice> TestData { get; set; }
        public InvoiceSeedDS()
        {
            TestData = new List<Invoice>()
            {
                new Invoice() { id=Guid.NewGuid(), customer="Lorem ipsum", address="Lorem ipsum", tel="Lorem ipsum",
                lines = new List<Line>() {
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 }
                } },
                new Invoice() { id=Guid.NewGuid(), customer="Lorem ipsum", address="Lorem ipsum", tel="Lorem ipsum",
                lines = new List<Line>() {
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 }
                } },
                new Invoice() { id=Guid.NewGuid(), customer="Lorem ipsum", address="Lorem ipsum", tel="Lorem ipsum",
                lines = new List<Line>() {
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 },
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 },
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 },
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 },
                    new Line() { cant = 10, description="Lorem ipsum", amount=1000 }
                } }
            };
        }
        public void AddNew(Invoice invoice)
        {
            
        }

        public IEnumerable<Invoice> GetAll()
        {
            return TestData;
        }

        public Invoice GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}