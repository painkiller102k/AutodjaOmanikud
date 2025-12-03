namespace AutodjaOmanikud
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CarId { get; set; }  
        public Car Car { get; set; }

        public DateTime Time { get; set; } 
    }
}
