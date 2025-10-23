

using HotelBookingSystem.Models;

namespace HotelBookingSystem.Services
{
    public class RoomService
    {
        private List<Room> rooms;

        public RoomService(List<Room> rooms)
        {
            this.rooms = rooms;

        }
        public void AddRoom(int number, string type, double price)
        {
            if (rooms.Any(r => r.RoomNumber == number))
            {
                Console.WriteLine("❌ Room already exists!");
                return;
            }
            rooms.Add(new Room(number, type, price));
            Console.WriteLine("✅ Room added successfully!");
        }

        // public List<Room> GetAvailableRooms() => rooms.Where(r => !r.IsBooked).ToList();
        public List<Room> GetAvailableRooms()
        {
            var available = rooms.Where(r => !r.IsBooked).ToList();

            if (available.Count == 0)
            {
                Console.WriteLine("⚠️ No available rooms!");
            }

            return available;
        }
    }
}