using CSProject.Auth.Models;

namespace CSProject.Auth.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserInfo userInfo);
    }
}