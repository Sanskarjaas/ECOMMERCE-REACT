using Core.Entities.Identity;

namespace Core.Intefaces{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}