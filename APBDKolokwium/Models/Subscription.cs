namespace APBDKolokwium.Models
{
    public class Subscription
    {
        public int IdSubscription { get; set; }
        public string Name { get; set; }
        public int RenewalPeriod { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }

        /* Navigations */
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
