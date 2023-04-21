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
    public class ItensController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ItensController(ApiDbContext context)
        {
            _context = context;
        }

   
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [Route("/api/CriarItem")]
        [HttpPost]
        public async Task<ActionResult<Itens>> CriarItem(Itens itens)
        {
            _context.Itens.Add(itens);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Deu certo");
        }

        [AllowAnonymous]
        [Route("/api/AllItems")]
        [HttpGet]
        public async Task<ActionResult<Itens>> AllItems()
        {
            try
            {
                var itens = await _context.Itens.Where(x => x.Imagem != null && x.Nome != null && x.quantidade != null && x.valor != null).ToListAsync();
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
