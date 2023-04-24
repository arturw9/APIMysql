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
public interface IItensRepository
{
    IEnumerable<Item> GetAllItens();
    Item GetByIdItem(string id);
    void AddItem(Item item);
    void UpdateItem(Item item);
    void DeleteItem(string id);
}
