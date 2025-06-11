namespace Stockify.API.Dto
{
    public class AuthResDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
