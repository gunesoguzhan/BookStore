namespace Webapi.TokenOperations.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expire { get; set; }
        public string RefreshToken { get; set; }
    }
}