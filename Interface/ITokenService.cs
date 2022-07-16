using NwOrdersAPI.Entities;

namespace NwOrdersAPI.Interface
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
