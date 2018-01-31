using System;
using System.Collections.Generic;
using Models.Domain;
using Service.Contracts.Services;
using Stripe;

namespace Services.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        public StripeCharge Charge(StripePaymentRequest stripePaymentRequest)
        {
            var myCharge = new StripeChargeCreateOptions()
            {
                SourceTokenOrExistingSourceId = stripePaymentRequest.TokenId,
                Amount = stripePaymentRequest.Amount,
                Currency = "usd",
                StatementDescriptor = "Crawfish Cup Tennis", 
                ReceiptEmail = stripePaymentRequest.ReceiptEmail,
                Description = stripePaymentRequest.Description,
                Metadata = new Dictionary<string, string>()
            };
            myCharge.Metadata["OurRef"] = "OurRef-" + Guid.NewGuid();

            try
            {
                return new StripeChargeService().Create(myCharge);
            }
            catch (StripeException ex)
            {
                throw new Exception(ex.StripeError.Message);
            }
        }
    }
}