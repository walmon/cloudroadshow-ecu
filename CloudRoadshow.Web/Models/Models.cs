using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoadshow.Web.Models
{
    public class Invoice
    {
        public Guid id { get; set; }
        public string customer { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
        public IEnumerable<Line> lines { get; set; }
    }
    public class Line
    {
        public double cant { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
    }
}
