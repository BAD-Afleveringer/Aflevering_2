using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;
using Aflevering_2.Services;


namespace Aflevering_2.Controllers;
[ApiController]
[Route("api/Providers")]
public class ProviderController : GenericController<Provider>
{
    public ProviderController(GenericService<Provider> service) : base(service) { }
}
