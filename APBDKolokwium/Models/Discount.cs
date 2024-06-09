﻿namespace APBDKolokwium.Models
{
    public class Discount
    {
        public int IdDiscount { get; set; }
        public int Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int IdClient { get; set; }

        /* Navigations */
        public virtual Client Client { get; set; }
    }
}
