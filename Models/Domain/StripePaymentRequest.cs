namespace Models.Domain
{
    public class StripePaymentRequest
    {
        public string TokenId { get; set; }
        public string Description { get; set; }
        public string ReceiptEmail { get; set; }
        public int Amount { get; set; }
    }
}