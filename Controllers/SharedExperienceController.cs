using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/SharedExperiences")]
public class SharedExperienceController : ControllerBase
{
    protected readonly GenericService<SharedExperience> _service;

    public SharedExperienceController(GenericService<SharedExperience> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SharedExperience>>> GetAll()
    {
        var SharedExperiences = await _service.GetAllAsync();
        return Ok(SharedExperiences);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SharedExperience>> GetById(int id)
    {
        var sharedExperience = await _service.GetByIdAsync(id);
        if (sharedExperience == null)
        {
            return NotFound();
        }
        return Ok(sharedExperience);
    }


    [HttpPost]
    public async Task<ActionResult> Create(SharedExperienceDTO SharedExperienceDTO)
    {
        var sharedExperience = new SharedExperience
        {
            SE_Title = SharedExperienceDTO.SE_Title,
            SE_Date = SharedExperienceDTO.SE_Date
        };

        await _service.addAsync(sharedExperience);
        return CreatedAtAction(nameof(GetById), new { id = sharedExperience.SharedExperienceId }, sharedExperience);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, SharedExperienceDTO SharedExperienceDTO)
    {
        if (SharedExperienceDTO == null)
        {
            return BadRequest();
        }

        var SharedExperience = new SharedExperience
        {
            SE_Title = SharedExperienceDTO.SE_Title,
            SE_Date = SharedExperienceDTO.SE_Date
        };

        await _service.UpdateAsync(Id, SharedExperience);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var sharedExperience = await _service.GetByIdAsync(id);
        if (sharedExperience == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(sharedExperience.SharedExperienceId);
        return NoContent();
    }
}
