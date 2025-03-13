using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Aflevering_2.Models;
using Aflevering_2.Services;

[ApiController]
[Route("api/[controller]")]
public class QueriesController : ControllerBase
{
    private readonly QueryService _service;
    public QueriesController(QueryService service)  // injecting QueryService
    {
        _service = service;
    }


    // Httpget for all. 

    [HttpGet("GetAllProviders")]
    public async Task<ActionResult> GetAllProviders()
    {
        var providers = await _service.GetAllProvidersAsync();
        return Ok(providers);
    }

    [HttpGet("GetAllExperiences")]
    public async Task<ActionResult> GetAllExperiences()
    {
        var experiences = await _service.GetAllExperiencesAsync();
        return Ok(experiences);
    }

    [HttpGet("GetAllSharedExperiences")]
    public async Task<ActionResult> GetAllSharedExperiences()
    {
        var sharedExperiences = await _service.GetAllSharedExperiencesAsync();
        return Ok(sharedExperiences);
    }

    [HttpGet("GetAllGuestsInSharedExperiences/{seId}")]
    public async Task<ActionResult> GetAllGuestInSharedExperiences(int seId)
    {
        var guestsInSharedExperiences = await _service.GetAllGuestsInSharedExperienceAsync(seId);
        return Ok(guestsInSharedExperiences);
    }

    [HttpGet("GetAllExperienceInSharedExperiences/{seID}")]
    public async Task<ActionResult> GetAllExperiencesInSharedExperienceAsync(int seID)
    {
        var experiencesInSharedExperiences = await _service.GetAllExperiencesInSharedExperienceAsync(seID);
        return Ok(experiencesInSharedExperiences);
    }

    [HttpGet("GetAllGuestsRegisteredforExperienceInSharedExperiences")]
    public async Task<ActionResult> GetAllGuestsRegisteredForExperiencesInSharedExperienceAsync([FromQuery] string eTitle)
    {
        var too_long = await _service.GetAllGuestsRegisteredForExperiencesInSharedExperienceAsync(eTitle);
        return Ok(too_long);
    }

    [HttpGet("GetPriceOfAllExperiences")]
    public async Task<ActionResult> GetPricesOfAllExperiences()
    {
        var GetPriceForAllExp = await _service.GetPricesOfAllExperiencesAsync();
        return Ok(GetPriceForAllExp);
    }

    [HttpGet("GetForAllExperiencesGuestsAndSales")]
    public async Task<ActionResult> GetForAllExperiencesGuestsAndSales()
    {
        var GetAllExp_Price_Guests = await _service.GetForAllExperiencesGuestsAndSalesAsync();
        return Ok(GetAllExp_Price_Guests);
    }

    [HttpGet("GetDiscountsForAllExp")]
    public async Task<ActionResult> GetDiscountsByAllExperiences()
    {
        var GetAllDiscountsByExp = await _service.GetDiscountsByAllExperiencesAsync();
        return Ok(GetAllDiscountsByExp);
    }


}






/* public async Task<IActionResult> GetAll([FromQuery] string entityType)
 {

     switch (entityType.ToLower())
     {
         case "providers":
             var providers = await _service.GetAllProvidersAsync();
             return Ok(providers);

         case "experiences":
             var experiences = await _service.GetAllExperiencesAsync();
             return Ok(experiences);

         case "sharedexperiences":
             var sharedexperiences = await _service.GetAllSharedExperiencesAsync();
             return Ok(sharedexperiences);

         case "experiences":
             var experiences = await _service.GetAllExperiencesAsync();
             return Ok(experiences);
     }

 }
*/