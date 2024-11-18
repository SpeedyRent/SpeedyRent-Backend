namespace Login_back.Presentation.DTOs
{
    public class VehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<string> Photos { get; set; }
    }
}