using Microsoft.EntityFrameworkCore;
using Autovermietung.models;
using Autovermietung.models.DB;
using System.Runtime.CompilerServices;

namespace Autovermietung;

public class Program
{
    public static async Task Main(string[] args)
    {
        Insert();
    }
    private static async void Insert()
    {
        Console.WriteLine("Create table-content!");
        using (DBManager dbManager = new DBManager())
        {
            await dbManager.Database.EnsureCreatedAsync();
            List<Car> cars = new List<Car>()
            {
                new Car("off-road", "VW", "Tiguan", 199.99m, true, 5, 5),
                new Car("family", "VW", "Tiguan", 99.99m, true, 5, 6),
                new Car("off-road", "VW", "Tiguan", 199.99m, false, 4, 3),
                new Car("blablaCar", "Tesla", "NoCLue", 499.98m, true, 5, 7),
                new Car("flyingCar", "Tesla", "flyingCar22", 999.99m, true, 3, 2),
                new Car("selfDrivingCar", "Tesla", "SDC22", 799.99m, true, 4, 4)

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
                new Additional("Dachträger",5.99m, 19),
                new Additional("Fahrradträger", 6.50m, 20),
                new Additional("Kindersitz", 5m, 39),
                new Additional("Kühlbox", 8.99m, 20)
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
                new Customer("Tobias","Laser", "Weißenbachgasse", "1", "6410", "Telfs", "Austria", "067761283914", "tlaser@tsn.at", new DateTime(2003,1,30)),
                new Customer("Erik", "Schmölzer", "IrgendEineStrasse", "15b", "6020", "Innsrbuck", "Austria", "061234567890", "eschmölzer@tsn.at", new DateTime(2004, 5,23)),
                new Customer("Thomas", "Kefer", "IrgendEineStrasse", "13b", "6020", "Innsrbuck", "Austria", "066969696969", "tkefer@tsn.at", new DateTime(2002, 9,16)),
                new Customer("Michael", "Perktold", "AndereStrasse", "69", "6600", "Reute", "Austria", "061234567890", "mperktold@tsn.at", new DateTime(2002, 10,22)),
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

            List<Bill> bills = new List<Bill>();
            for (int i = 0; i < 4; i++)
            {
                Bill bill = new Bill((new DateTime(2022, 11, 14)).AddDays(i), (new DateTime(2022, 11, 28)).AddDays(i * 2));
                bill.Customer = dbManager.Customers.Take(1 + (i % dbManager.Customers.Count())).OrderBy(c => c.CustomerID).Last();
                for (int j = 0; j < i; j++)
                {
                    bill.Additionals.Add(dbManager.Additionals.Take(1 + j).OrderBy(a => a.AdditionalId).Last());
                }
                bills.Add(bill);
            }
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
            List<CarBill> carBills = new List<CarBill>();

            for (int i = 0; i < 4; i++)
            {
                CarBill carBill = new CarBill(12.34m * (1 + i));
                carBill.Car = dbManager.Cars.Take(1 + (i % cars.Count)).OrderBy(c => c.CarId).Last();
                carBill.Bill = dbManager.Bills.Take(1 + (i % bills.Count)).OrderBy(b => b.BillID).Last();
                carBills.Add(carBill);
            }
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
            Console.WriteLine("Done");
        }
        
    }

    private static void Select()
    {
        var cars = new List<Car>();

    }
}