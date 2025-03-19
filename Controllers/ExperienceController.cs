using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExperienceController : ControllerBase
{
    protected readonly GenericService<Experience> _service;

    public ExperienceController(GenericService<Experience> service)
    {
        _service = service;
    }


    // get all
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Experience>>> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities);
    }


    // get by id
    [HttpGet("{id}")]
    public async Task<ActionResult<Experience>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }


    // create experience 
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateExperienceDTO createExperienceDTO)
    {
        var experience = new Experience
        {
            ProviderId = createExperienceDTO.ProviderId,
            Title = createExperienceDTO.Title,
            Price = createExperienceDTO.Price
        };

        await _service.addAsync(experience);
        return CreatedAtAction(nameof(GetById), new { id = experience.ExperienceId }, experience);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, CreateExperienceDTO createExperienceDTO)
    {
        var experience = new Experience
        {
            ProviderId = createExperienceDTO.ProviderId,
            Title = createExperienceDTO.Title,
            Price = createExperienceDTO.Price
        };

        await _service.UpdateAsync(id, experience);
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