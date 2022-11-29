using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string? StreetNr { get; set; } // kann null sein, wenn keine weitere Adresse vorhanden
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual List<Bill> Bills { get; set; } = new List<Bill>();
        // ctors
        public Customer() : this("", "", "", "", "", "", "", "", "", DateTime.Now)
        {
            // default ctor
        }

        public Customer(string firstname, string lastname, string street, string? streetrn,
            string zipcode, string city, string country, string phonenr,
            string email, DateTime bday)
        {
            FirstName = firstname; LastName = lastname; Street = street; StreetNr = streetrn;
            ZipCode = zipcode; City = city; Country = country; Phone = phonenr; Email = email;
            BirthDate = bday;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}" +
                $"{BirthDate}" +
                $"{((StreetNr != null) ? $" {StreetNr}" : "")}"
            + $", {ZipCode} {City}, {Country}" +
            $"{Phone} {Email} \n{Bills}"
            ;
        }
    }
}
