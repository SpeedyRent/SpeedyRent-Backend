namespace Login_back.Domain.Model
{
    public class Request
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string CarId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string Contract { get; set; } = "Pending";
    }
}