namespace HotelBookingSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, string phone, string email)
        {
            CustomerId = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

        public void DisplayCustomer()
        {
            Console.WriteLine($"Customer ID: {CustomerId} | Name: {Name} | Phone: {Phone} | Email: {Email}");
        }
    }
}
