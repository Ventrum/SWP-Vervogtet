using Microsoft.EntityFrameworkCore;
using Autovermietung.models;
using Autovermietung.models.DB;

namespace Autovermietung;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Create table-content!");
        using (DBManager dbManager = new DBManager())
        {
            await dbManager.Database.EnsureCreatedAsync();
            List<Car> cars = new List<Car>()
            {
                new Car("off-road", "VW", "Tiguan", 199.99m, true, 5, 5),
                new Car("family", "VW", "Tiguan", 99.99m, true, 5, 6),
                new Car("off-road", "VW", "Tiguan", 199.99m, false, 4, 3)

            };
            foreach (Car car in cars)
            {
                var _cars = dbManager.Cars.Where(
                    c => c.Type == car.Type
                    && c.Brand == car.Brand
                    && c.Model == car.Model
                    && c.Price == car.Price
                    && c.HasAirCondition == car.HasAirCondition
                    && c.AmountSeats == car.AmountSeats
                    && c.SpaceSuitcases == car.SpaceSuitcases
                    );
                if (!_cars.Any())
                    dbManager.Cars.Add(car);
            }
            await dbManager.SaveChangesAsync();
            List<Additional> additionals = new List<Additional>()
            {
                new Additional("Dachträger",5.99m,10)
            };
            foreach (Additional additional in additionals)
            {
                var _additional = dbManager.Additionals.Where(
                    a => a.Name == additional.Name
                    && a.Price == additional.Price
                    && a.AvailableAmount == additional.AvailableAmount
                    );
                if (!_additional.Any())
                    dbManager.Additionals.Add(additional);
            }
            await dbManager.SaveChangesAsync();
            List<Customer> customers = new List<Customer>()
            {
                new Customer("Tobias","Laser", "Weißenbachgasse", "1", "6410", "Telfs", "Austria", "067761283914", "tlaser@tsn.at", new DateTime(2003,1,30))
            };
            foreach (Customer customer in customers)
            {
                var _customer = dbManager.Customers.Where(
                    c => c.FirstName == customer.FirstName
                    && c.LastName == customer.LastName
                    );
                if (!_customer.Any())
                    dbManager.Customers.Add(customer);
            }
            await dbManager.SaveChangesAsync();
            Bill bill0 = new Bill(new DateTime(2022, 11, 14), new DateTime(2022, 11, 28));
            bill0.Customer = dbManager.Customers.First();
            bill0.Additionals.Add(dbManager.Additionals.First());
            List<Bill> bills = new List<Bill>()
            {
                bill0
            };
            foreach (Bill bill in bills)
            {
                
                var _bill = dbManager.Bills.Where(
                    b => b.StartDate == bill.StartDate 
                    && b.EndDate == bill.EndDate
                    && b.Customer.CustomerID == bill.Customer.CustomerID
                    );
                if (!_bill.Any())
                    dbManager.Bills.Add(bill);
            }
            await dbManager.SaveChangesAsync();
            List<CarBill> carBills = new List<CarBill>()
            {
                new CarBill(12.34m)
            };
            carBills[0].Car = dbManager.Cars.First();
            carBills[0].Bill = dbManager.Bills.First();
            foreach (CarBill carBill in carBills)
            {

                var _carBill = dbManager.CarsBill.Where(
                    cb => cb.Discount == carBill.Discount
                    && cb.Car == carBill.Car
                    && cb.Bill == carBill.Bill
                    );
                if (!_carBill.Any())
                    dbManager.CarsBill.Add(carBill);
            }
            await dbManager.SaveChangesAsync();
        }
    }
}