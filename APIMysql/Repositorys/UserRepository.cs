﻿using APIMysql.Data;
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

    public void Delete(string email)
    {
        var user = _context.Users.Find(email);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
