using HotelBookingSystem.Interfaces;
using HotelBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Services
{
    public class BookingService: IBookingService
    {
        private List<Room> rooms;
        private List<Customer> customers;
        private List<Booking> bookings;

        private int bookingCounter = 1;
        
        public BookingService(List<Customer>customers, List<Room>rooms)
        {
            this.customers = customers;
            this.rooms = rooms;
            bookings = new List<Booking>();
        }
        public void BookRoom(int customerId, int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found!");
                return;
            }
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.IsBooked);
            if (room == null)
            {
                Console.WriteLine("❌ Room not available!");
                return;
            }
            // Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
            // DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? "");
            // Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
            // DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? "");

            room.IsBooked = true;
            var booking = new Booking(bookingCounter++, customer, room, checkIn, checkOut);
            bookings.Add(booking);

            Console.WriteLine($"✅ Room {room.RoomNumber} booked successfully for {customer.Name}");
        }
        public void CancelBooking(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("❌ Booking not found!");
                return;
            }
            booking.Room.IsBooked = false;
            bookings.Remove(booking);
            Console.WriteLine($"✅ Booking {bookingId} canceled successfully.");

        }
        // public List<Booking> GetAllBookings() => bookings;
        public List<Booking> GetAllBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("⚠️ No bookings yet!");
            }

            return bookings;
        }


        // public void ShowAvailableRooms()
        // {
        //     var availableRooms = rooms.Where(r => !r.IsBooked).ToList();

        //     if (availableRooms.Count == 0)
        //     {
        //         Console.WriteLine("❌ No available rooms!");
        //         return;
        //     }

        //     Console.WriteLine("Availabe Rooms:");
        //     foreach (var room in availableRooms)
        //     {
        //         room.DisplayInfo();
        //     }
        // }
        
        // public void ShowAllBookings()
        // {
        //     if (bookings.Count == 0)
        //     {
        //         Console.WriteLine("❌ No bookings found!");
        //         return;
        //     }

        //     Console.WriteLine("All Booking: ");
        //     foreach(var booking in bookings)
        //     {
        //         booking.DisplayBooking();
        //     }
        // }
    }
}