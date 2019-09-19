using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}