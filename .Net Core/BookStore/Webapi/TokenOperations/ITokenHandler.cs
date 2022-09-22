using Webapi.TokenOperations.Models;

namespace Webapi.TokenOperations
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int days = 0, int hours = 0, int minutes = 0, int seconds = 0);
    }
}