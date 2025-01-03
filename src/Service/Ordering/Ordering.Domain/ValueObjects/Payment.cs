namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment() { }
        private Payment(string cardName, string cardNumber, string expiratoin, string cVV, int paymentMethod)
        {
            CardName = cardName; 
            CardNumber = cardNumber; 
            Expiration = expiratoin; 
            CVV = cVV; 
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiratoin, string cVV, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cVV);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cVV.Length,3);

            return new Payment( cardName,  cardNumber,  expiratoin,  cVV,  paymentMethod);
        }
    }
}
