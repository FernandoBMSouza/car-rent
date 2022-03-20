using System;
using System.Globalization;
using Project.Entities;
using Project.Services;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter rental data: ");
            System.Console.Write("Car model: ");
            string model = Console.ReadLine();

            System.Console.Write("Pickup (dd/MM/yyyy hh:MM): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            System.Console.Write("Return (dd/MM/yyyy hh:MM): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            System.Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            
            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental);
            System.Console.WriteLine();
            System.Console.WriteLine("INVOICE:");
            System.Console.WriteLine(carRental.Invoice);
        }
    }
}