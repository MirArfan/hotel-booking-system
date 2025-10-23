using System;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Room> rooms = new();
        List<Customer> customers = new();

        RoomService roomService = new(rooms);
        BookingService bookingService = new(customers, rooms);

        while (true)
        {
            Console.WriteLine("\n🏨 Hotel Booking System");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Book Room");
            Console.WriteLine("4. Cancel Booking");
            Console.WriteLine("5. Show Available Rooms");
            Console.WriteLine("6. Show All Bookings");
            Console.WriteLine("7. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Room Number: ");
                    int num = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Type: single/double/suite ");
                    string type = Console.ReadLine() ?? "Standard";
                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine() ?? "0");
                    roomService.AddRoom(num, type, price);
                    break;

                case 2:
                    Console.Write("Enter Customer ID: ");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Enter Customer Phone : ");
                    string phone = Console.ReadLine() ?? "00000";
                    Console.Write("Enter Customer Email : ");
                    string email = Console.ReadLine() ?? "unknown@example.com";
                    customers.Add(new Customer(id, name, phone, email));
                    Console.WriteLine("✅ Customer added successfully!");
                    break;

                case 3:
                    Console.Write("Enter Customer ID: ");
                    int cid = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Room Number: ");
                    int rnum = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
                    DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? "");
                    Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
                    DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? "");
                    bookingService.BookRoom(cid, rnum, checkIn, checkOut);
                    break;

                case 4:
                    Console.Write("Enter Booking ID: ");
                    int bid = int.Parse(Console.ReadLine() ?? "0");
                    bookingService.CancelBooking(bid);
                    break;

                case 5:
                    Console.WriteLine("Available Rooms:");
                    var available = roomService.GetAvailableRooms();
                    foreach (var r in available)
                            Console.WriteLine(r);
                    break;

                case 6:
                    Console.WriteLine("All Bookings:");
                    var allBookings = bookingService.GetAllBookings();
                        foreach (var b in allBookings)
                            Console.WriteLine(b);
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("❌ Invalid option!");
                    break;
            }
        }
            
    }
}
