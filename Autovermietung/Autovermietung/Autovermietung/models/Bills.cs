using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Bills
    {
        public int BillID { get; set; }
        public int CarID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }

        public Customer Customer { get; set; }

        // ctors
        public Bills() : this(0, 0, DateTime.Now, DateTime.Now, 0.0, null)
        {
            // default ctor
        }

        public Bills(int billid, int carid, DateTime startdate,
            DateTime enddate, double totalprice, Customer customer)
        {
            BillID = billid; CarID = carid;
            StartDate = startdate; EndDate = enddate; TotalPrice = totalprice;
            Customer = customer;
        }
        public override string ToString()
        {
            return $"{BillID} {CarID} \n{StartDate} - {EndDate} \n {TotalPrice}€ \n{Customer}";
        }
    }
}
