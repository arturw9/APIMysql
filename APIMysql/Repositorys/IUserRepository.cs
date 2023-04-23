using APIMysql.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetByEmail(string email);
    User GetById(string id);
    void Add(User user);
    void Update( User user);
    void Delete(string id);
}
