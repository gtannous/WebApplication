namespace WebApplication2_API
{
    public interface IUserService
    {
        Task<User?> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}