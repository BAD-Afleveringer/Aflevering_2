using Aflevering_2.Models;
using Aflevering_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aflevering_2.Controllers
{
    [ApiController]
    [Route("api/sharedexperiences")]
    public class SharedExperienceController : GenericController<SharedExperience>
    {
        public SharedExperienceController(GenericService<SharedExperience> service) : base(service) { }
    }
}
