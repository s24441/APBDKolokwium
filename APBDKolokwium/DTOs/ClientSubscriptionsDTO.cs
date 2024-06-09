namespace APBDKolokwium.DTOs
{
    public class ClientSubscriptionsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int? Discount { get; set; }

        public IEnumerable<SubscriptionDTO> Subscriptions { get; set; }
    }
}
