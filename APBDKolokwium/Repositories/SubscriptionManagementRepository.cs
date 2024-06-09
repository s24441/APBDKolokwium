using APBDKolokwium.DTOs;
using APBDKolokwium.Interfaces;
using APBDKolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDKolokwium.Repositories
{
    public class SubscriptionManagementRepository : ISubscriptionManagementRepository
    {
        private readonly SubscriptionManagementDbContext _context;

        public SubscriptionManagementRepository(SubscriptionManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ClientSubscriptionsDTO?> GetClientSubscriptionsAsync(int idClient)
        {
            var clientSubscriptions = await _context
                .Clients
                .Include(e => e.Discounts)
                .Include(e => e.Payments)
                .ThenInclude(e => e.Subscription)
                .FirstOrDefaultAsync(client => client.IdClient == idClient);

            if (clientSubscriptions == null)
                return null;

            int? discount = clientSubscriptions.Discounts.Sum(d => d.Value);

            if (discount == 0)
                discount = null;
            if (discount > 50)
                discount = 50;

            return new ClientSubscriptionsDTO()
            {
                FirstName = clientSubscriptions.FirstName,
                LastName = clientSubscriptions.LastName,
                Email = clientSubscriptions.Email,
                Phone = clientSubscriptions.Phone,
                Discount = clientSubscriptions.Discounts.Sum(d => d.Value),
                Subscriptions = clientSubscriptions.Payments
                    .GroupBy(e => e.Subscription)
                    .Select(g => new SubscriptionDTO()
                    {
                        IdSubscription = g.Key.IdSubscription,
                        Name = g.Key.Name,
                        RenewalPeriod = g.Key.RenewalPeriod,
                        TotalPaidAmount = (int)g.Sum(gp => gp.Value)
                    })
            };
        }

        public async Task<int> AddPaymentAsync(PaymentDTO payment)
        {
            var result = 0;

            var client = await _context.Clients
                .Include(e => e.Discounts)
                .FirstOrDefaultAsync(c => c.IdClient == payment.IdClient);

            if (client == null)
                throw new Exception("Client does not exists in the database");

            int discount = client.Discounts.Sum(d => d.Value);
            if (discount > 50) discount = 50;
            var paymentFactor = (1D - discount / 100);

            var subscription = await _context
                .Subscriptions
                .FirstOrDefaultAsync(s => s.IdSubscription == payment.IdSubscription);

            if (subscription == null)
                throw new Exception("Subscription does not exists in the database");

            if (subscription.EndTime < DateTime.Now)
                throw new Exception("Subscription is inactive");

            var dateFrom = await _context.Sales.Where(s => s.IdSubscription == payment.IdSubscription).Select(s => s.CreatedAt).MaxAsync();
            var dateTo = dateFrom.AddMonths(subscription.RenewalPeriod);

            if (_context.Payments.Any(p => p.IdSubscription == payment.IdSubscription && p.Date >= dateFrom && p.Date <= dateTo))
                throw new Exception("Subscription already payed");

            if (payment.Payment != subscription.Price * (1 - discount/100))
                throw new Exception("Wrong payment amount");

            var newPayment = new Payment()
            {
                IdClient = payment.IdClient,
                IdSubscription = payment.IdSubscription,
                Date = DateTime.Now,
                Value = payment.Payment
            };

            _context.Payments.Add(newPayment);

            result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
