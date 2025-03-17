// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// [ApiController]
// [Route("api/[controller]")]
// public class GenericController<T> : ControllerBase where T : class
// {
//     protected readonly GenericService<T> _service;

//     public GenericController(GenericService<T> service)
//     {
//         _service = service;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<T>>> GetAll()
//     {
//         var entities = await _service.GetAllAsync();
//         return Ok(entities);
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<T>> GetById(int id)
//     {
//         var entity = await _service.GetByIdAsync(id);
//         if (entity == null)
//         {
//             return NotFound();
//         }
//         return Ok(entity);
//     }

//     [HttpPost]
//     public virtual async Task<ActionResult> Create([FromBody] T entity)
//     {

//         if (entity == null)
//         {
//             return BadRequest();
//         }

//         await _service.addAsync(entity);
//         return CreatedAtAction(nameof(GetById), new { id = entity }, entity);
//     }

//     [HttpPut("{id}")]
//     public async Task<ActionResult> Update(int id, [FromBody] T entity)
//     {
//         if (entity == null)
//         {
//             return BadRequest();
//         }

//         await _service.UpdateAsync(entity);
//         return NoContent();
//     }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult> Delete(int id)
//     {
//         var entity = await _service.GetByIdAsync(id);
//         if (entity == null)
//         {
//             return NotFound();
//         }

//         await _service.DeleteAsync(id);
//         return NoContent();
//     }
// }
