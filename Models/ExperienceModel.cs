using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Aflevering_2.Swagger;

namespace Aflevering_2.Models;
/* public class PriceValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is double price)
        {
            if (price > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Price must be a positive number.");
            }
        }
        return new ValidationResult("Invalid price value.");
    }
} */

public class AboveZeroAttribute : ValidationAttribute
{
    public AboveZeroAttribute()
    {
        ErrorMessage = "Price must be above zero.";
    }

    public override bool IsValid(object value)
    {
        if (value is double price)
        {
            return price >= 0; // Ensure price is 0 or greater
        }
        return false;
    }
}


/*
public class AboveZeroAttribute : Attribute, IModelValidator
{
    public string ErrorMessage { get; set; } = "price must be above zero";
    public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
    {

        // check if its positive
        if (context.Model is double price)
        {
            if (price < 0)
            {
                return new List<ModelValidationResult>{
                    new ModelValidationResult("", ErrorMessage)
                };
            }
            return Enumerable.Empty<ModelValidationResult>();
        }

        return Enumerable.Empty<ModelValidationResult>();
    }

}
*/


// data representation

public class Experience  // representation of table
{
    public int ExperienceId { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    [AboveZero]
    public int Price { get; set; } // ? = allow nulls
    public int ProviderId { get; set; }

    public ICollection<Discount>? Discounts { get; set; }

    public ICollection<SharedExperience>? SharedExperiences { get; set; }
}

// used to create experience without discount or shared experience
public class CreateExperienceDTO
{
    [Required]
    public string? Title { get; set; }

    [Required]
    [AboveZero]
    //[Range(0, double.MaxValue, ErrorMessage = "Price needs to be above 0. ")]
    public int Price { get; set; }
    public int ProviderId { get; set; }

}
