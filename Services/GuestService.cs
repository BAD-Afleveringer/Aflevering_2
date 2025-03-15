using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2;

namespace Aflevering_2.Services;


public class GuestService : GenericService<Guest>
{
    //ExperienceDbContext _context;

    public GuestService(ExperienceDbContext context) : base(context) { }


    // public async override Task<List<Guest>> GetAllAsync()
    // {
    //     return await _context.Guests.ToListAsync();
    // }

    // public async Task<Guest?> GetByIdAsync(int Id)
    // {
    //     return await _context.Guests.FindAsync(Id);
    // }
}