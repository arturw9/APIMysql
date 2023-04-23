using APIMysql.Data;
using APIMysql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMysql.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [EnableCors("AllowAlls")]

    public class UsersController : Controller
    {
        private readonly ApiDbContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(ApiDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [Route("/")]
        [HttpGet]


        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [Route("/api/Login")]
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
            try
            {
                if (dados != null)
                {
                    return true;
                }
                else
                {
                    return NotFound("E-mail ou senha não compativeis");
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
   
        [AllowAnonymous]
        [Route("/api/CriarUser")]
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

        [AllowAnonymous]
        [Route("/api/AllUsers")]
        [HttpGet]
        public async Task<ActionResult<User>> AllUsers()
        {   
            try
            {
                var usuarios = await _context.Users.Where(x => x.Senha != null && x.Email != null).ToListAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("/api/DetailsUser")]
        [HttpGet]
        public IActionResult Details(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [AllowAnonymous]
        [Route("/api/UpdateUsers")]
        [HttpPut]
        public IActionResult Edit(string id,[FromBody] User user)
        {
            var existingUser = _userRepository.GetById(user.Id.ToString());

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Email = user.Email;
            existingUser.Senha = user.Senha;


            _userRepository.Update(existingUser);

            return Ok(user);
        }

        [AllowAnonymous]
        [Route("/api/DeleteUser")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [AllowAnonymous]
        [Route("/api/DeleteUser")]
        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
