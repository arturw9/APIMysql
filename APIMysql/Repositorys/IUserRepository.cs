using APIMysql.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetByEmail(string email);
    void Add(User user);
    void Update(User user);
    void Delete(string email);
}
