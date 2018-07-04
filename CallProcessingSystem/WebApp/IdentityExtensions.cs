using System.Security.Claims;
using System.Security.Principal;
using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.AspNet.Identity;

namespace WebApp
{
    public static class IdentityExtensions
    {
        /// <summary>
        ///     Создает идентификатор <see cref="ClaimsIdentity" /> для <seealso cref="Identity" />
        /// </summary>
        public static ClaimsIdentity CreateUserIdentity(this Identity user)
        {
            var id = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
            id.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            id.AddClaim(new Claim(ClaimTypes.Name, user.Email, "http://www.w3.org/2001/XMLSchema#string"));
            id.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"));
            id.AddClaim(new Claim(ClaimTypes.Role, user.Role == RoleType.Executor ? "executor" : "operator",
                "http://www.w3.org/2001/XMLSchema#string"));
            return id;
        }

        /// <summary>
        ///     Проверяет, является ли пользователь оператором />
        /// </summary>
        public static bool IsOperator(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated && principal.IsInRole("operator");
        }

        /// <summary>
        ///     Проверяет, является ли пользователь исполнителем />
        /// </summary>
        public static bool IsExecutor(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated && principal.IsInRole("executor");
        }
    }
}