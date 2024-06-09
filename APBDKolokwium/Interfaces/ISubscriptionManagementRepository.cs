using APBDKolokwium.DTOs;

namespace APBDKolokwium.Interfaces
{
    public interface ISubscriptionManagementRepository
    {
        public Task<ClientSubscriptionsDTO?> GetClientSubscriptionsAsync(int idClient);
        public Task<int> AddPaymentAsync(PaymentDTO payment);
    }
}
