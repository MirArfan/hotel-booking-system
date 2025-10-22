using System;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;


namespace HotelBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BookingService bookingService = new BookingService();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n===== HOTEL BOOKING SYSTEM =====");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Book Room");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("5. Show Available Rooms");
                Console.WriteLine("6. Show All Bookings");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");


                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        bookingService.AddRoom();
                        break;
                    case 2:
                        bookingService.AddCustomer();
                        break;
                    case 3:
                        bookingService.BookRoom();
                        break;
                    case 4:
                        bookingService.CancelBooking();
                        break;
                    case 5:
                        bookingService.ShowAvailableRooms();
                        break;
                    case 6:
                        bookingService.ShowAllBookings();
                        break;
                    case 7:
                        running = false;
                        Console.WriteLine("Thank you for using Hotel Booking System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}