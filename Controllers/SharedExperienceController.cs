using Microsoft.AspNetCore.Mvc;
using Aflevering_2.Models;

namespace Aflevering_2.Controllers;

[Route("api/SharedExperiences")]
public class SharedExperienceController : GenericController<SharedExperience>
{
    public SharedExperienceController(GenericService<SharedExperience> service) : base(service) { }
}
