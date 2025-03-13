using Aflevering_2.Models;
using Microsoft.EntityFrameworkCore;

public class QueryService
{
    ExperienceDbContext _context;

    public QueryService(ExperienceDbContext context)
    {
        _context = context;
    }


    public async Task<List<Provider>> GetAllProvidersAsync()
    {
        return await _context.Providers.ToListAsync();
    }

    public async Task<List<Experience>> GetAllExperiencesAsync()
    {
        return await _context.Experiences.ToListAsync();
    }

    public async Task<List<SharedExperience>> GetAllSharedExperiencesAsync()
    {
        var sortedResults = _context.SharedExperiences
                                    .OrderByDescending(p => p.SE_Date);
        return await sortedResults.ToListAsync();
    }

    public async Task<List<Guest>> GetAllGuestsInSharedExperienceAsync(int seId)
    {
        return await _context.SharedExperiences
            .Where(se => se.SharedExperienceId == seId)
            .Include(se => se.Guests)
            .SelectMany(se => se.Guests ?? new List<Guest>()) // Basically just a select where we select a collection instead
            .ToListAsync();
    }

    public async Task<List<Experience>> GetAllExperiencesInSharedExperienceAsync(int seID)
    {
        return await _context.SharedExperiences
        .Where(se => se.SharedExperienceId == seID)
        .Include(se => se.Experiences)
        .SelectMany(se => se.Experiences ?? new List<Experience>())
        .ToListAsync();
    }


    public async Task<List<Guest>> GetAllGuestsRegisteredForExperiencesInSharedExperienceAsync(string eTitle)
    {
        return await _context.Guests
            .Where(g => g.SharedExperiences
                .Any(se => se.Experiences
                    .Any(e => e.Title == eTitle)))
            .ToListAsync();
    }

    public async Task<List<double>> GetPricesOfAllExperiencesAsync()
    {
        var experiences = await _context.Experiences.ToListAsync();

        List<double> prices = new List<double>
        {
            experiences.Average(e => e.Price),
            experiences.Max(e => e.Price),
            experiences.Min(e => e.Price)
        };

        return prices;
    }

    public async Task<List<Tuple<string, int, double>>> GetForAllExperiencesGuestsAndSalesAsync()
    {
        var experiences = await GetAllExperiencesAsync();
        List<Tuple<string, int, double>> experienceSalesData = new List<Tuple<string, int, double>>();

        foreach (var experience in experiences)
        {

            var Guests = await GetAllGuestsRegisteredForExperiencesInSharedExperienceAsync(experience.Title);
            int count = Guests.Count();
            experienceSalesData.Add(new Tuple<string, int, double>(experience.Title, count, (double)count * experience.Price));
        }
        return experienceSalesData;
    }

    public async Task<List<Discount>> GetDiscountsByAllExperiencesAsync()
    {
        return await _context.Experiences
                             .Include(exp => exp.Discounts)
                             .SelectMany(exp => exp.Discounts ?? new List<Discount>())
                             .ToListAsync();


        // var experiences = await _context.Experiences.ToListAsync();


        // List<Discount> discounts = new List<Discount>();
        // foreach (var experience in experiences)
        // {
        //     int percentage = experience.Discounts.Select(discount => discount.discountPercentage);
        //     var guests = await GetAllGuestsRegisteredForExperiencesInSharedExperienceAsync(experience.Title);
        //     int count = guests.Count();


        //     discounts.Add(count, ,, )

        // }

    }

}