using System;
using Microsoft.Extensions.Caching.Memory;
using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid TokenId, JwtDto jwt)
            => cache.Set(GetJwtKey(TokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid TokenId)
            => cache.Get<JwtDto>(GetJwtKey(TokenId));

        private static string GetJwtKey(Guid TokenId) 
            => $"{TokenId}-jwt";
    }
}