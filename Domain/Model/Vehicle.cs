namespace Login_back.Domain.Model
{
    public class Vehicle
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<string> Photos { get; set; } = new List<string>();
        public string OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}