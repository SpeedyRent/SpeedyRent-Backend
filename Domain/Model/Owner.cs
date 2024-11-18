namespace Login_back.Domain.Model
{
    public class Owner
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OwnerUserId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}