
/*
public class UserService : GenericService<User>
{
    public UserService(AppDbContext context) : base(context) { }
}
*/

using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;

public class ExperienceService : GenericService<Experience>
{
    public ExperienceService(ExperienceDbContext context) : base(context) { }
}