namespace APBDKolokwium.Models
{
    public class Payment
    {
        public int IdPayment { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int IdClient { get; set; }
        public int IdSubscription { get; set; }

        /* Navigations */

        public virtual Client Client { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
