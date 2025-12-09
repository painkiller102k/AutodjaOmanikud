namespace AutodjaOmanikud
{
    public class Service
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime Time { get; set; } 

        public Car Car { get; set; }
        public ServiceType ServiceType { get; set; }
    }


}
