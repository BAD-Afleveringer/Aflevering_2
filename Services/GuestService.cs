using System.Reflection.Metadata.Ecma335;
using Aflevering_2.Models;
using Microsoft.EntityFrameworkCore;

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