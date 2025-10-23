using HotelBookingSystem.Models;
using System.Collections.Generic;

namespace HotelBookingSystem.Interfaces
{
    public interface IBookingService
    {
        void BookRoom(int CustomerId, int roomNumber, DateTime checkIn, DateTime checkOut);
        void CancelBooking(int bookingId);
        List<Booking> GetAllBookings();
    }
}
