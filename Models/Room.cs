namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int RoomNumber{get; set;}
        public string Type {get; set;}
        public double Price {get; set;}
        public bool IsBooked {get; set;}

        public Room(int roomNumber, string type, double price)
        {
            RoomNumber=roomNumber;
            Type=type;
            Price=price;
            IsBooked=false;
        }

        public void DisplayInfo()
        {
            string status = IsBooked ? "Booked" : "Available";
            Console.WriteLine($"Room : {RoomNumber} | Type : {Type} | Price: {Price} | Status: {status}");
        }
        public override string ToString()
        {
            return $"Room {RoomNumber} | {Type} | {Price} BDT/night | {(IsBooked ? " Booked" : " Available")}";
        }
    }
}