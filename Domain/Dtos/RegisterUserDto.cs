namespace Login_back.Domain.Dtos
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        public string DniImage { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PhotoUser { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DriverLicense { get; set; } = string.Empty;
    }

}