using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Additional
    {
        public int AdditionalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableAmount { get; set; }
        public virtual List<Bill> Bills { get; set; } = new List<Bill>();
        public Additional(string name, decimal price, int availableAmount)
        {
            this.Name = name;
            this.Price = price;
            this.AvailableAmount = availableAmount;
        }

        public Additional() : this("", 0.0m, 0) { }
        public override string ToString()
        {
            return "ID: " + this.AdditionalId + "\tname: " + this.Name + "\tprice: " + this.Price + "\tavailable amount:"+this.AvailableAmount;
        }
    }
}
