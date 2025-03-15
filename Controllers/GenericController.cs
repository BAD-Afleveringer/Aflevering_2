using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aflevering_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly GenericService<T> _service;

        public GenericController(GenericService<T> service)
        {
            _service = service;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity }, entity);
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(entity);
            return NoContent();
        }

        // DELETE: api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
