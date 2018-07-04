using Domain.CQRS;
using Microsoft.AspNet.Identity;

namespace WebApp
{
    /// <summary>
    ///     Менеджер паролей
    /// </summary>
    public class PasswordManager : IPasswordManager
    {
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public PasswordManager()
        {
            _passwordHasher = new PasswordHasher();
        }

        /// <summary>
        ///     Проверка пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="hash">Захэшированый пароль</param>
        /// <returns></returns>
        public bool ValidatePassword(string password, string hash)
        {
            return _passwordHasher.VerifyHashedPassword(hash, password) != PasswordVerificationResult.Failed;
        }

        /// <summary>
        ///     Генерация нового хэшированиго пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(password);
        }
    }
}