namespace Domain.CQRS
{
    public interface IPasswordManager
    {
        bool ValidatePassword(string password, string hash);

        string HashPassword(string password);
    }
}