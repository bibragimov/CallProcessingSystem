using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

namespace WebApp
{
    public sealed class IdentityValidator
    {
        private readonly IRepository<Identity> _userRepository;

        public IdentityValidator(IRepository<Identity> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateIdentity(CookieValidateIdentityContext validateIdentityContext)
        {
            var claimsIdentity = validateIdentityContext.Identity;
            if (claimsIdentity.IsAuthenticated)
            {
                var userId = claimsIdentity.GetUserId<long>();

                var identity = _userRepository.Find(userId);

                var isValid = identity != null;

                if (isValid)
                    validateIdentityContext.ReplaceIdentity(claimsIdentity);
                else
                    validateIdentityContext.RejectIdentity();
            }
        }
    }
}