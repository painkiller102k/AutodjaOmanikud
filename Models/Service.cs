namespace AutodjaOmanikud
{
    public class Service
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public DateTime Time { get; set; }

        public bool IsPaid { get; set; } = false;
    }



}
