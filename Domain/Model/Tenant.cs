namespace Login_back.Domain.Model
{
    public class Tenant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TenantUserId { get; set; }
        public ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}