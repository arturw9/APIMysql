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
    public class ItensController : Controller
    {
        private readonly ApiDbContext _context;
        private readonly IItensRepository _itemRepository;

        public ItensController(ApiDbContext context, IItensRepository itemRepository)
        {
            _context = context;
            _itemRepository = itemRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [Route("/api/CriarItem")]
        [HttpPost]
        public async Task<ActionResult<Item>> CriarItem(Item itens)
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
        public async Task<ActionResult<Item>> AllItems()
        {
            try
            {
                var itens = await _context.Itens.Where(x => x.Id != null).ToListAsync();
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("/api/UpdateItens")]
        [HttpPut]
        public IActionResult Edit(string id, [FromBody] Item item)
        {
            var existingItem = _itemRepository.GetByIdItem(id.ToString());

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Imagem = item.Imagem;
            existingItem.Nome = item.Nome;
            existingItem.valor = item.valor;
            existingItem.quantidade = item.quantidade;

            _itemRepository.UpdateItem(existingItem);

            return Ok(item);
        }

        [AllowAnonymous]
        [Route("/api/DeleteItem")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var item = _itemRepository.GetByIdItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [AllowAnonymous]
        [Route("/api/DeleteItem")]
        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _itemRepository.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
