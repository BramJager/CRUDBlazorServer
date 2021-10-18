using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDBlazorServer.Data;

namespace CRUDBlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DndbooksController : ControllerBase
    {
        private readonly Dndbookrepository _repository;

        public DndbooksController(Dndbookrepository repository)
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
