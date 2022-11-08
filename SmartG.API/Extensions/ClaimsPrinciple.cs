using System;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace SmartG.API.Extensions
{
    public static class ClaimsPrinciple
    {
       public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirst(ClaimTypes.GivenName)?.Value;
        }

    }
}

