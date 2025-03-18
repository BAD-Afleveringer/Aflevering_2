using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/[controller]")]
public class ProviderTestController : ControllerBase
{
    protected readonly GenericService<Provider> _service;

    public ProviderTestController(GenericService<Provider> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Provider>>> GetAll()
    {
        var providers = await _service.GetAllAsync();
        return Ok(providers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Provider>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateProviderDTO createProviderDTO)
    {
        var provider = new Provider
        {
            TouristicOperatorPermitPdf = createProviderDTO.TouristicOperatorPermitPdf,
            PhoneNumber = createProviderDTO.PhoneNumber,
            Address = createProviderDTO.Address
        };

        await _service.addAsync(provider);
        return CreatedAtAction(nameof(GetById), new { id = provider.ProviderId }, provider);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, CreateProviderDTO createProviderDTO)
    {
        if (createProviderDTO == null)
        {
            return BadRequest();
        }
        var provider = new Provider
        {
            TouristicOperatorPermitPdf = createProviderDTO.TouristicOperatorPermitPdf,
            PhoneNumber = createProviderDTO.PhoneNumber,
            Address = createProviderDTO.Address
        };


        await _service.UpdateAsync(Id, provider);
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