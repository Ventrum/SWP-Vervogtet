using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Bill
    {
        public int BillID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<Additional> Additionals { get; set; } = new List<Additional>();
        public virtual List<CarBill> CarBills { get; set; } = new List<CarBill>();

        // ctors
        public Bill() : this(DateTime.Now, DateTime.Now)
        {
            // default ctor
        }

        public Bill(DateTime startdate,
            DateTime enddate)
        {
            StartDate = startdate; EndDate = enddate; 
        }
        public override string ToString()
        {
            return $"{BillID}  \n{StartDate} - {EndDate} \n{Customer}";
        }
    }
}
