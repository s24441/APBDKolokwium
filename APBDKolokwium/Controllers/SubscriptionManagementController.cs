using APBDKolokwium.DTOs;
using APBDKolokwium.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBDKolokwium.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionManagementController : Controller
    {
        private readonly ISubscriptionManagementRepository _repository;

        public SubscriptionManagementController(ISubscriptionManagementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> GetClientSubscriptions([FromRoute] int idClient)
        {
            var clientSubscriptions = await _repository.GetClientSubscriptionsAsync(idClient);

            if (clientSubscriptions == null)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDTO payment)
        {
            var result = 0;
            try
            {
                result = await _repository.AddPaymentAsync(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (result < 1)
                return BadRequest("No payment added");

            return Ok(result);
        }
    }
}
