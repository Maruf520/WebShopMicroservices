namespace Ordering.Application.Dtos;
  public record PaymentDto(string CardName, string CardNumber, string Expiratoin, string Cvv, int PaymentMethod);

