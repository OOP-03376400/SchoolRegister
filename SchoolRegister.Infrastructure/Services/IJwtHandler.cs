using System;
using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid UserId, string role);
    }
}