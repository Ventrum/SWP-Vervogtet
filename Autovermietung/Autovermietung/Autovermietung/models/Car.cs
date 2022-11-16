﻿using System;
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

        public virtual List<CarBill> CarBills { get; set; }

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
            return "ID: " + this.CarId + "\ttpye: " + this.Type + "\tbrand: " + this.Brand + "\tmodel: " + this.Model + "\tprice: " + this.Price + "\thas air condition: " + this.HasAirCondition + "\tamount of Seats: " + this.AmountSeats + "\tspace for suitcases: " + this.SpaceSuitcases;
        }
    }
}
