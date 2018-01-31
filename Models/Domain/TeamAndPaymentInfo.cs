namespace Models.Domain
{
    public class TeamAndPaymentInfo
    {
        public TeamWithPlayers TeamWithPlayers { get; set; }
        public StripePaymentRequest StripePaymentRequest { get; set; }
    }
}