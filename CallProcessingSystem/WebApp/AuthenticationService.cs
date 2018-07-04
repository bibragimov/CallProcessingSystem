using Domain.CQRS;
using Domain.Entities;
using Domain.Entities.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebApp.Models;

namespace WebApp
{
    public class AuthenticationService
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IRepository<Identity> _identityRepository;
        private readonly IPasswordManager _passwordManager;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public AuthenticationService(IAuthenticationManager authenticationManager,
            IRepository<Identity> identityRepository, IPasswordManager passwordManager)
        {
            _authenticationManager = authenticationManager;
            _identityRepository = identityRepository;
            _passwordManager = passwordManager;
        }

        /// <summary>
        ///     Аутентификация
        /// </summary>
        public void Login(LoginViewModel loginModel, bool remember = true)
        {
            var user = _identityRepository.Find(x => x.Email == loginModel.Email);

            if (user != null)
            {
                // Проверка пароля
                if (!_passwordManager.ValidatePassword(loginModel.Password, user.Password)) return;

                var userIdentity = user.CreateUserIdentity();

                Logout();

                var authenticationProperties = new AuthenticationProperties
                {
                    IsPersistent = remember
                };

                _authenticationManager.SignIn(authenticationProperties, userIdentity);
            }
        }

        /// <summary>
        ///     Sign-out
        /// </summary>
        public void Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.ExternalBearer);
        }
    }
}