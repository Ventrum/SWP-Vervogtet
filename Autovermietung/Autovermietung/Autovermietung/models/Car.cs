using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool IsFourDoor { get; set; }
        public int AmountSeats { get; set; }
        public int SpaceSuitcases { get; set; }

        //virtual List<CarBill> CarBills;

        public Car(string type, string brand, string model, decimal price, bool isFourDoor, int amountSeats, int SpaceSuitcases)
        {
            this.Type = type;
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.IsFourDoor = isFourDoor;
            this.AmountSeats = amountSeats;
            this.SpaceSuitcases = SpaceSuitcases;
        }

        public Car() : this("none-type", "none-brand", "none-model", 0.0m, false, 4, 1)
        {

        }

        public override string ToString()
        {
            return this.CarId + "\t" + this.Type + "\t" + this.Brand + "\t" + this.Model + "\t" + this.Price + "\t" + this.IsFourDoor + "\t" + this.AmountSeats + "\t" + this.SpaceSuitcases;
        }
    }
}
