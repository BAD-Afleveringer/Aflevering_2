using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Aflevering_2.Swagger;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace Aflevering_2.Models
{
    public class AboveZeroAttribute : ValidationAttribute
    {
        public AboveZeroAttribute()
        {
            ErrorMessage = "Price must be above zero.";
        }

        public override bool IsValid(object value)
        {
            if (value is int price)
            {
                return price > 0; // Ensure price is greater than 0
            }
            return false;
        }
    }

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
        [SwaggerSchema(Description = "Title of the experience", Nullable = false)]
        [FromQuery]
        public string? Title { get; set; }

        [Required]
        [FromQuery]
        [SwaggerSchema(Description = "Price of the experience, must be above zero", Nullable = false)]
        [AboveZero]
        public int Price { get; set; }

        [SwaggerSchema(Description = "ID of the provider", Nullable = false)]
        [FromQuery]
        public int ProviderId { get; set; }
    }
}
