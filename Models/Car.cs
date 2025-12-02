using AutodjaOmanikud;

namespace AutodjaOmanikud
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

    }
}
