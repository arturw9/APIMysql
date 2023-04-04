﻿using APIMysql.Data;
using APIMysql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIMysql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAlls")]

    public class UsersController : Controller
    {
        private readonly ApiDbContext _context;

        public UsersController(ApiDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [Route("/")]
        [HttpGet]


        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [Route("/Login")]
        [HttpGet]
        public async Task<ActionResult<bool>> Login(string? dados)
        {
            return Ok(dados);
        }

        [AllowAnonymous]
        [Route("/api/Login")]
        [HttpPost]
        public async Task<ActionResult<bool>> Login(User user){
            var dados = _context.Users.FirstOrDefault(x=>x.Email == user.Email && x.Senha == user.Senha);
            if (dados != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> CriarUser(User user){
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
            return Ok("Deu certo");
        }
    }

}