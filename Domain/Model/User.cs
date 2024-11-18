namespace Login_back.Domain.Model
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Dni { get; set; }
        public string? DniImage { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? PhotoUser { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DriverLicense { get; set; }
    }
}
