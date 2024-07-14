namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string messasge) : base(messasge)
        {

        }
        public BadRequestException(string messasge, string details) : base(messasge)
        {
            Details = details;
        }
        public string? Details { get; }
    }
}
