using CRUDBlazorServer.Data;
using CRUDBlazorServer.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDBlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndbooksController : ControllerBase
    {
        private readonly IRepository<Dndbook> _repository;

        public DndbooksController(IRepository<Dndbook> repository)
        {
            _repository = repository;
        }

        // GET: api/Dndbooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dndbook>>> GetDndbooks()
        {
            var books = await _repository.GetAll();

            return Ok(books);
        }

        // GET: api/Dndbooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dndbook>> GetDndbook(int id)
        {
            var dndbook = await _repository.GetById(id);

            if (dndbook == null)
            {
                return NotFound();
            }

            return Ok(dndbook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDndbook(Dndbook dndbook)
        {
            await _repository.Update(dndbook);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Dndbook>> PostDndbook(Dndbook dndbook)
        {
            await _repository.Add(dndbook);

            return CreatedAtAction("GetDndbook", new { id = dndbook.DndbookId }, dndbook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDndbook(int id)
        {
            var dndbook = await _repository.GetById(id);
            if (dndbook == null)
            {
                return NotFound();
            }

            await _repository.Delete(dndbook);

            return NoContent();
        }
    }
}
