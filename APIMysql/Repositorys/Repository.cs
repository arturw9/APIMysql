using APIMysql.Data;
using APIMysql.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public User GetById(string id)
    {
        return _context.Users.FirstOrDefault(u => u.Id.ToString() == id);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        var userUp = _context.Users.Find(user.Id);
        userUp.Email = user.Email;
        userUp.Senha = user.Senha;
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var user = _context.Users.FirstOrDefault(x=>x.Id.ToString() == id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}

public class ItemRepository : IItensRepository
{
    private readonly ApiDbContext _context;

    public ItemRepository(ApiDbContext dbContext)
    {
        _context = dbContext;
    }
    public IEnumerable<Item> GetAllItens()
    {
        return _context.Itens.ToList();
    }


    public Item GetByIdItem(string id)
    {
        return _context.Itens.FirstOrDefault(u => u.Id.ToString() == id);
    }

    public void AddItem(Item item)
    {
        _context.Itens.Add(item);
        _context.SaveChanges();
    }

    public void UpdateItem(Item item)
    {
        var itemUp = _context.Itens.Find(item.Id);
        itemUp.Imagem = item.Imagem;
        itemUp.Nome = item.Nome;
        itemUp.valor = item.valor;
        itemUp.quantidade = item.quantidade;
        _context.SaveChanges();
    }

    public void DeleteItem(string id)
    {
        var item = _context.Itens.FirstOrDefault(x => x.Id.ToString() == id);
        _context.Itens.Remove(item);
        _context.SaveChanges();
    }
}