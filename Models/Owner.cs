namespace AutodjaOmanikud
{
    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
