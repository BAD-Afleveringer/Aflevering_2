using Aflevering_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Aflevering_2.Services;


public class DiscountService : GenericService<Discount>
{
    public DiscountService(ExperienceDbContext context) : base(context)
    {
    }


    // dependenciy injection
    // ExperienceDbContext _context;
    // public DiscountService(ExperienceDbContext context)
    // {
    //     _context = context;
    // }

    // public async Task<IEnumerable<Discount>> GetAllDiscounts()
    // {

    //     return await _context.Discounts.ToListAsync(); // har fat i discount tabellen
    // }

    // public async Task<Discount?> GetDiscountById(int id)
    // {
    //     return await _context.Discounts.FindAsync(id);
    // }

    // public async Task<Discount> CreateDiscount(Discount discount)
    // {
    //     _context.Discounts.Add(discount); // creates one new discount to dbcontext (not up to database)
    //     await _context.SaveChangesAsync(); // saves to database

    //     return discount;
    // }

    // public async Task<Discount?> UpdateDiscount(int id, Discount discount)
    // {
    //     var existingDiscount = await _context.Discounts.FindAsync(id);
    //     if (existingDiscount == null)
    //         return null;

    //     existingDiscount.discountPercentage = discount.discountPercentage;
    //     existingDiscount.minGuests = discount.minGuests;
    //     existingDiscount.ExperienceId = discount.ExperienceId;

    //     await _context.SaveChangesAsync();
    //     return existingDiscount;
    // }

    // public async Task<bool> DeleteDiscount(int id)
    // {
    //     var discount = await _context.Discounts.FindAsync(id);
    //     if(discount == null)
    //         return false;

    //     _context.Discounts.Remove(discount);
    //     await _context.SaveChangesAsync();
    //     return true;
    // }

}