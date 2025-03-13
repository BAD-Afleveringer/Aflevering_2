using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/Discounts")]
public class DiscountController : GenericController<Discount>
{
    public DiscountController(GenericService<Discount> service) : base(service) { }
}
