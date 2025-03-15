using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;
using Aflevering_2.Services;

namespace Aflevering_2.Controllers;
[ApiController]
[Route("api/Discounts")]
public class DiscountController : GenericController<Discount>
{
    public DiscountController(GenericService<Discount> service) : base(service) { }
}
