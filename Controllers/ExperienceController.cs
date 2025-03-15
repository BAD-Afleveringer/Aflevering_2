using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;
using Aflevering_2.Services;


namespace Aflevering_2.Controllers;

[ApiController]
[Route("api/experiences")]
public class ExperienceController : GenericController<Experience>
{
    public ExperienceController(GenericService<Experience> service) : base(service) { }
}
