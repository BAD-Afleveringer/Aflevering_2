using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/[controller]")]
public class GuestController : ControllerBase
{
    protected readonly GenericService<Guest> _service;

    public GuestController(GenericService<Guest> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateGuestDTO createGuestDTO)
    {
        var Guest = new Guest
        {
            GuestAge = createGuestDTO.GuestAge,
            GuestNumber = createGuestDTO.GuestNumber,
            GuestName = createGuestDTO.GuestName
        };

        await _service.addAsync(Guest);
        return CreatedAtAction(nameof(GetById), new { id = Guest.GuestId }, Guest);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, CreateGuestDTO createGuestDTO)
    {
        if (createGuestDTO == null)
        {
            return BadRequest();
        }
        var Guest = new Guest
        {
            GuestAge = createGuestDTO.GuestAge,
            GuestNumber = createGuestDTO.GuestNumber,
            GuestName = createGuestDTO.GuestName
        };


        await _service.UpdateAsync(Id, Guest);
        return NoContent();
    }

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