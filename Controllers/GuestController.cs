using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;
using Aflevering_2.Services;


namespace Aflevering_2.Controllers;

[ApiController]
[Route("api/Guests")]
public class GuestController : GenericController<Guest>
{
    public GuestController(GenericService<Guest> service) : base(service) { }
}
