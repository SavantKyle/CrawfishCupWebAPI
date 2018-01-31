using Models.Domain;
using Stripe;

namespace Service.Contracts.Services
{
    public interface IStripePaymentService
    {
        StripeCharge Charge(StripePaymentRequest stripePaymentRequest);
    }
}