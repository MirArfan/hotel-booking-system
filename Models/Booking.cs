namespace HotelBookingSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(int bookingId, Customer customer, Room room, DateTime checkIn, DateTime checkOut)
        {
            BookingId = bookingId;
            Customer = customer;
            Room = room;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
        }

        public void DisplayBooking()
        {
            Console.WriteLine($"Booking ID: {BookingId} | Room: {Room.RoomNumber} | Customer: {Customer.Name} | " +
                              $"Check-In: {CheckInDate.ToShortDateString()} | Check-Out: {CheckOutDate.ToShortDateString()}");
        }
    }
}
