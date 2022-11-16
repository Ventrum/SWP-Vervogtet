using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class CarBill
    {
        public int CarBillId { get; set; }
        public decimal Discount { get; set; }
        public virtual Car Car { get; set; }
        public virtual CarBill Bill { get; set; }
        public CarBill(decimal discount) { Discount = discount; }
        public CarBill() : this(0.0m) { }
        public override string ToString()
        {
            return "ID: " + this.CarBillId + "\t" + this.Discount;
        }
    }
}
