using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class BookingService
    {
        private List<Room>rooms =new List<Room>();
        private List<Customer>customers=new List<Customer>();
        private List<Booking>bookings= new List<Booking>();

        private int bookingCounter=1;
        private int customerCounter=1;


        public void AddRoom()
        {
            Console.Write("Enter Room Number : ");
            int roomNumber=int.Parse(Console.ReadLine()?? "0");

            Console.Write("Enter Room Type : ");
            string type = Console.ReadLine()?? "Single";

            Console.Write("Enter Room Price : ");
            double price =double.Parse(Console.ReadLine()?? "0");

            rooms.Add(new Room(roomNumber, type, price));
            Console.WriteLine("✅ Room added successfully!");
        }

        public void AddCustomer()
        {
            Console.Write("Enter Customer Name : ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter Customer Phone : ");
            string phone = Console.ReadLine() ?? "00000";

            Console.Write("Enter Customer Email : ");
            string email = Console.ReadLine() ?? "unknown@example.com";

            customers.Add(new Customer(customerCounter++, name, phone, email));
            Console.WriteLine("✅ Customer added successfully!");
        }

        public void BookRoom()
        {
            Console.Write("ENter Customer ID : ");
            int customerId = int.Parse(Console.ReadLine() ?? "0");
            var customer = customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found!");
                return;
            }

            Console.Write("Enter Room Number : ");
            int roomNumber = int.Parse(Console.ReadLine() ?? "0");
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.IsBooked);
            if (room == null)
            {
                Console.WriteLine("❌ Room not available!");
                return;
            }
            Console.Write("Enter Check-In Date (yyyy-mm-dd): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? "");
            Console.Write("Enter Check-Out Date (yyyy-mm-dd): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? "");

            room.IsBooked = true;
            var booking = new Booking(bookingCounter++, customer, room, checkIn, checkOut);
            bookings.Add(booking);

            Console.WriteLine("✅ Room booked successfully!");
        }
        public void CancelBooking()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine() ?? "0");
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("❌ Booking not found!");
                return;
            }
            booking.Room.IsBooked = false;
            bookings.Remove(booking);
            Console.WriteLine("✅ Booking cancelled successfully!");

        }

        public void ShowAvailableRooms()
        {
            var availableRooms = rooms.Where(r => !r.IsBooked).ToList();

            if (availableRooms.Count == 0)
            {
                Console.WriteLine("❌ No available rooms!");
                return;
            }

            Console.WriteLine("Availabe Rooms:");
            foreach (var room in availableRooms)
            {
                room.DisplayInfo();
            }
        }
        
        public void ShowAllBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine("❌ No bookings found!");
                return;
            }

            Console.WriteLine("All Booking: ");
            foreach(var booking in bookings)
            {
                booking.DisplayBooking();
            }
        }
    }
}