namespace APBDKolokwium.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        /* Navigations */
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
