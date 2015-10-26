using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoadshow.Web.Models
{
    interface IInvoiceDS
    {
        IEnumerable<Invoice> GetAll();
        Invoice GetById(Guid id);
        void AddNew(Invoice invoice);
    }
}
