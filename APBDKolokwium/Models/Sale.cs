﻿namespace APBDKolokwium.Models
{
    public class Sale
    {
        public int IdSale { get; set; }
        public int IdClient { get; set; }
        public int IdSubscription { get; set; }
        public DateTime CreatedAt { get; set; }

        /* Navigations */
        public virtual Client Client { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
