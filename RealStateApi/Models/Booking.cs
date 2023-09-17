namespace RealStateApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = "";
        public string PassporNumber { get; set; } = "";
        public string Form { get; set; } = "";
        public string To { get; set; } = "";
        public string Status { get; set; }
    }
}
