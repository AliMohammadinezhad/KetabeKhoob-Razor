using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace KetabeKhoob.Razor.Infrastructure.Utils
{
    public static class UserUtils
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) 
                throw new ArgumentNullException(nameof(principal));
            
            return Convert.ToInt64(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
