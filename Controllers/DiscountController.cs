using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/[controller]")]
public class DiscountController : ControllerBase
{
    protected readonly GenericService<Discount> _service;

    public DiscountController(GenericService<Discount> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Discount>>> GetAll()
    {
        var discounts = await _service.GetAllAsync();
        return Ok(discounts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Discount>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }


    [HttpPost]
    public async Task<ActionResult> Create(DiscountDTO discountDTO)
    {
        var discount = new Discount
        {
            minGuests = discountDTO.minGuests,
            discountPercentage = discountDTO.discountPercentage,
            ExperienceId = discountDTO.ExperienceId
        };

        await _service.addAsync(discount);
        return CreatedAtAction(nameof(GetById), new { id = discount.DiscountID }, discount);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int Id, DiscountDTO discountDTO)
    {
        if (discountDTO == null)
        {
            return BadRequest();
        }

        var discount = new Discount
        {
            minGuests = discountDTO.minGuests,
            discountPercentage = discountDTO.discountPercentage,
            ExperienceId = discountDTO.ExperienceId
        };

        await _service.UpdateAsync(Id, discount);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var discount = await _service.GetByIdAsync(id);
        if (discount == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(discount.DiscountID);
        return NoContent();
    }
}