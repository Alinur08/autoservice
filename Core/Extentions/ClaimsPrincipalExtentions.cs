using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core1.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)?.Select(c => c.Value).ToList();
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
        public static int ClaimNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return int.Parse(claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public static string ClaimEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirst(ClaimTypes.Email).Value;
        }
    }
}
